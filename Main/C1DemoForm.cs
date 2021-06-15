using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1Ribbon;
using C1.C1Zip;

namespace ControlExplorer
{
    public partial class C1DemoForm : Form
    {
        protected static string TEMP_DIR = System.Environment.GetEnvironmentVariable("tmp");
        private Hashtable tempFiles = null;
        private ArrayList properties = null;
        private string description = "";
        private string code;
        
        public C1DemoForm()
        {
            InitializeComponent();
            properties = null;
            description = "";
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ArrayList Properties
        {
            get
            {
                if (properties == null)
                    properties = new ArrayList();

                return properties;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Description
        {
            get
            {
                return description;
            }
        }

        //public enum ControlExplorerVisualStyleEnum { Office2007Blue, Office2007Silver, Office2007Black, Office2010Blue, Office2010Silver, Office2010Black, System };
        VisualStyle _controlExplorerVisualStyle;
        public VisualStyle ControlExplorerVisualStyle
        {
            get
            {
                return _controlExplorerVisualStyle;
            }
            set
            {
                _controlExplorerVisualStyle = value;
                OnRaiseControlExplorerVisualStyleChanged(new EventArgs());
            }
        }

        public delegate void ControlExplorerVisualStyleChanged(object sender, EventArgs e);
        public event EventHandler RaiseControlExplorerVisualStyleChanged;

        protected virtual void OnRaiseControlExplorerVisualStyleChanged(EventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler handler = RaiseControlExplorerVisualStyleChanged;

            // Event will be null if there are no subscribers
            if (handler != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                
                //e.Message += String.Format(" at {0}", DateTime.Now.ToString());

                // Use the () operator to raise the event.
                handler(this, e);
            }
        }


        //public virtual string DemoCode
        //{
        //    get
        //    {
        //        if (code != null)
        //            return code;

        //        Type t = this.GetType();
        //        Stream s = t.Assembly.GetManifestResourceStream(t.FullName + ".zip");

        //        if (s == null)
        //        {
        //            code = "No code is available.";
        //            return code;
        //        }

        //        string guid = System.Guid.NewGuid().ToString();
        //        string zipFile = String.Format("{0}\\{1}.zip", TEMP_DIR, guid);

        //        byte[] bits = new byte[s.Length];
        //        s.Read(bits, 0, (int)s.Length);
        //        System.IO.File.WriteAllBytes(zipFile, bits);

        //        C1ZipFile z = new C1ZipFile();
        //        z.Open(zipFile);

        //        StreamReader reader = new StreamReader(z.Entries[0].OpenReader());
        //        code = reader.ReadToEnd();
        //        reader.Close();

        //        z.Close();
        //        File.Delete(zipFile);
        //        return code;
        //    }
        //}

        public string DemoCode
        {
            get
            {
                if (code != null)
                    return code;

                string filename = base.GetType().ToString().Replace('.', '/') + ".cs";

                System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();

                //Type t = base.GetType();
                Stream s = asm.GetManifestResourceStream("ControlExplorer.SourceCode.zip");
                
                C1ZipFile z = new C1ZipFile();
                z.Open(s);
                if (z.Entries[filename] != null)
                {
                    StreamReader reader = new StreamReader(z.Entries[filename].OpenReader());
                    code = reader.ReadToEnd();
                    reader.Close();
                }
                else
                {
                    code = "No code available.";
                }
                z.Close();
                return code;
            }
        }

        static public void ClearContainer(Control.ControlCollection controls)
        {
            while (controls.Count > 0)
            {
                Control c = controls[0];
                controls.Remove(c);
                c.Dispose();
            }
        }

        public virtual void DisplayIn(Control.ControlCollection controls)
        {
            ClearContainer(controls);
            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            Size = new Size(1, 1);
            controls.Add(this);
            MainForm.Form.UpdateVisualStyle(); // propagate visual style from the main ribbon form to all child controls
            Dock = DockStyle.Fill;
            try
            {
                Visible = true;
            }
            catch (Exception x)
            {
                Visible = false;
                throw new Exception(x.Message, x.GetBaseException());
            }
        }

        public void AddProperty(string propertyName, object target, string longName)
        {
            if (properties == null)
                properties = new ArrayList();

            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(target);
            PropertyDescriptor pd = pdc.Find(propertyName, false);
            properties.Add(new Association(pd, target, longName));
        }

        public void AddProperty(string propertyName, object target)
        {
            AddProperty(propertyName, target, "");
        }

        public void AddPropertySeparator()
        {
            if (properties != null)
                properties.Add("separator");
        }

        public void AddPropertyColumnBreak()
        {
            if (properties != null)
                properties.Add("colbreak");
        }

        public void AddPropertyHeader(string text)
        {
            if (properties == null)
                properties = new ArrayList();

            properties.Add(text);
        }

        public void AddDescription(string text)
        {
            if (description != "")
            {
                description = description + Environment.NewLine + text;
            }
            else
            {
                description = text;
            }
        }

        public void AddCode(string text)
        {
            code = text;
        }

        public string GetTempFileName(string ext)
        {
            if (tempFiles == null)
                tempFiles = new Hashtable();

            if (!tempFiles.Contains(ext))
            {
                string tempFile = GetUniqueTempFileName(ext);
                tempFiles.Add(ext, tempFile);
            }

            return tempFiles[ext].ToString();
        }

        public string GetUniqueTempFileName(string ext)
        {
            string appName = AppDomain.CurrentDomain.FriendlyName;
            string guid = System.Guid.NewGuid().ToString();
            return String.Format("{0}\\{1}_{2}{3}", TEMP_DIR, appName, guid, ext);
        }

        protected void DeleteTempFile()
        {
            if (tempFiles == null)
                return;

            try
            {
                foreach (string s in tempFiles.Values)
                    File.Delete(s);

                tempFiles = null;
            }
            catch
            {
            }
        }

        public string DemoConnectionString
        {
            get
            {
                return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|C1Demo.mdb;Persist Security Info=False";
            }
        }

        public DataTable DemoDataSource()
        {
            return DemoDataSource("", false);
        }

        public DataTable DemoDataSource(string member)
        {
            return DemoDataSource(member, false);
        }

        public DataTable DemoDataSource(string member, bool custom)
        {
            string sql = "SELECT * FROM Products";
            DataTable dt = new DataTable();
            if (custom)
            {
                sql = member;
            }
            else if(member.Equals("EmployeeOrders"))
            {
                sql = "SELECT DISTINCTROW Orders.OrderID, Orders.OrderDate, Shippers.CompanyName, Customers.Country, [FirstName] & \" \" & [LastName] AS Salesperson, Products.ProductName AS Product, [Order Details].UnitPrice, [Order Details].Quantity, [Order Details].Discount, CCur([Order Details].[UnitPrice]*[Quantity]*(1-[Discount])/100)*100 AS ExtendedPrice FROM Shippers INNER JOIN (Products INNER JOIN ((Employees INNER JOIN (Customers INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID) ON Employees.EmployeeID = Orders.EmployeeID) INNER JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID) ON Products.ProductID = [Order Details].ProductID) ON Shippers.ShipperID = Orders.ShipVia;";
            }
            else if (member.Equals("Invoices"))
            {
                sql = "SELECT DISTINCTROW Orders.ShipName, Orders.ShipAddress, Orders.ShipCity, Orders.ShipRegion, Orders.ShipPostalCode, Orders.ShipCountry, Orders.CustomerID, Customers.CompanyName, Customers.Address, Customers.City, Customers.Region, Customers.PostalCode, Customers.Country, [FirstName] & \" \" & [LastName] AS Salesperson, Orders.OrderID, Orders.OrderDate, Orders.RequiredDate, Orders.ShippedDate, Shippers.CompanyName, [Order Details].ProductID, Products.ProductName, [Order Details].UnitPrice, [Order Details].Quantity, [Order Details].Discount, CCur([Order Details].[UnitPrice]*[Quantity]*(1-[Discount])/100)*100 AS ExtendedPrice, Orders.Freight FROM Shippers INNER JOIN (Products INNER JOIN ((Employees INNER JOIN (Customers INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID) ON Employees.EmployeeID = Orders.EmployeeID) INNER JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID) ON Products.ProductID = [Order Details].ProductID) ON Shippers.ShipperID = Orders.ShipVia;";
            }
            else if (member.Equals("Customers"))
            {
                sql = "SELECT * FROM Customers";
            }
            else if (member.Equals("Customers_OrderByCountry"))
            {
                sql = "SELECT * FROM Customers ORDER BY Country";
            }
            else if (member.Equals("Employees"))
            {
                sql = "SELECT * FROM Employees";
            }
            else if (member.Equals("Products"))
            {
                sql = "SELECT * FROM Products";
            }
            else if (member.Equals("Products2"))
            {
                sql = "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice, UnitsInStock, Discontinued FROM Products";
            }
            else if (member.Equals("Composer"))
            {
                sql = "SELECT * FROM Composer";
            }
            else if (member.Equals("Suppliers"))
            {
                sql = "SELECT * FROM Suppliers";
            }
            else if (member.Equals("Orders"))
            {
                sql = "SELECT * FROM Orders";
            }
            OleDbDataAdapter da = new OleDbDataAdapter(sql, DemoConnectionString);
            da.Fill(dt);
            return dt;
        }
    }
}
