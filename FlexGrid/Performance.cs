using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ControlExplorer.FlexGrid
{
    public partial class Performance : C1DemoForm
    {
        int count = 20000;
        List<MyItem> list = new List<MyItem>();
        BackgroundWorker worker = new BackgroundWorker(); 

        public Performance()
        {
            InitializeComponent();

            // set AutoResize to false for fastest load time
            c1FlexGrid1.AutoResize = false;

            // set background worker
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.WorkerReportsProgress = true;

            numericUpDown1.Maximum = int.MaxValue;
        }

        private void c1Command1_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            c1Command1.Enabled = false;

            // clear FlexGrid
            c1FlexGrid1.DataSource = null;
            c1FlexGrid1.Rows.Count = 1;
            c1FlexGrid1.Cols.Count = 1;

            count = (int)txtCount.Value;            
            progressBar.Maximum = count;

            // run background worker
            worker.RunWorkerAsync();  
        }

        #region Background worker

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Random rnd = new Random();
            var list = new List<MyItem>(count);

            try
            {
                for (int i = 0; i < count; i++)
                {
                    // report progress periodically
                    if (i % 1000 == 0)
                    {
                        worker.ReportProgress(0, i);
                    }

                    MyItem m = new MyItem();
                    m.ID = i;
                    m.姓名 = "Row" + i.ToString();
                    m.标记 = i % 2 == 0 ? true : false;
                    m.日期 = DateTime.Now.Add(new TimeSpan(i, i, i));
                    m.值1 = (double)rnd.Next(int.MaxValue);
                    m.值2 = (double)rnd.Next(int.MaxValue);
                    m.值3 = (double)rnd.Next(int.MaxValue);
                    m.值4 = (double)rnd.Next(int.MaxValue);
                    m.值5 = (double)rnd.Next(int.MaxValue);
                    m.值6 = (double)rnd.Next(int.MaxValue);
                    list.Add(m);
                }
                worker.ReportProgress(0, count);
            }
            catch (OutOfMemoryException)
            {
                // system does not have enough memory to create the data source
                list.Clear();
            }
            e.Result = list;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var items = (IList)e.Result;
            if (items.Count == 0)
            {
                MessageBox.Show("超出内存。请试一个个数较少的项目集。");
            }
            else
            {
                try
                {
                    // load flexgrid with redraw = false for best performance
                    c1FlexGrid1.Redraw = false;
                    c1FlexGrid1.DataSource = items;
                    c1FlexGrid1.Redraw = true;

                    // custom editors
                    c1FlexGrid1.Cols["日期"].Editor = dateTimePicker1;
                    c1FlexGrid1.Cols["值1"].Editor = numericUpDown1;
                    c1FlexGrid1.Cols["值2"].Editor = numericUpDown1;
                    c1FlexGrid1.Cols["值3"].Editor = numericUpDown1;
                    c1FlexGrid1.Cols["值4"].Editor = numericUpDown1;
                    c1FlexGrid1.Cols["值5"].Editor = numericUpDown1;
                    c1FlexGrid1.Cols["值6"].Editor = numericUpDown1;
                }
                catch (Exception)
                {
                    MessageBox.Show("超出内存。请试一个个数较少的项目集。");
                }
            }
            c1Command1.Enabled = true;
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = (int)e.UserState;
            lblStatus.Text = string.Format("{0} / {1} 行", ((int)e.UserState).ToString(), count.ToString());
        }

        #endregion

        private void Performance_Load(object sender, EventArgs e)
        {

        }
    }

    public class MyItem
    {
        public int ID { get; set; }
        public string 姓名 { get; set; }
        public bool? 标记 { get; set; }
        public DateTime? 日期 { get; set; }
        public double? 值1 { get; set; }
        public double? 值2 { get; set; }
        public double? 值3 { get; set; }
        public double? 值4 { get; set; }
        public double? 值5 { get; set; }
        public double? 值6 { get; set; }
    }
}
