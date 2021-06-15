using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1Schedule;
using C1.C1Schedule;


namespace ControlExplorer.Schedule
{
    public partial class DragDrop : C1DemoForm
    {

        public DragDrop()
        {
            InitializeComponent();
        }

        private void DragDrop_Load(object sender, EventArgs e)
        {
            c1FlexGrid1.AddItem("\t创建计划文档");
            c1FlexGrid1.AddItem("\t销售会议");
            c1FlexGrid1.AddItem("\t结束陈述");
            c1FlexGrid1.AddItem("\t开始ACM训练");
            c1FlexGrid1.AddItem("\t和产品团队开会");
            c1FlexGrid1.AddItem("\t全体成员大会");
            c1FlexGrid1.AddItem("\t预算会议");
            c1FlexGrid1.AddItem("\t高级调试");
            c1FlexGrid1.AllowAddNew = true;

            Appointment ap1 = c1Schedule1.DataStorage.AppointmentStorage.Appointments.Add();
            ap1.Location = "小会议室";
            ap1.Body = "不见不散";
            ap1.Subject = "电话会议";
            ap1.Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            ap1.End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 0, 0);
            ap1.Label = c1Schedule1.DataStorage.LabelStorage.Labels[11];


            Appointment ap2 = c1Schedule2.DataStorage.AppointmentStorage.Appointments.Add();
            ap2.Location = "小会议室";
            ap2.Body = "不见不散";
            ap2.Subject = "电话会议";
            ap2.Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            ap2.End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 0, 0);
            ap2.Label = c1Schedule1.DataStorage.LabelStorage.Labels[11];
        }

        private void c1Schedule1_DragDrop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(typeof(C1.C1Schedule.Appointment)))
            {
                Appointment app;
                app = (Appointment)e.Data.GetData(typeof(C1.C1Schedule.Appointment));
                //Data automatically gets set to appointment's Body text
                //Assign data to Subject text if empty
                if (string.IsNullOrEmpty(app.Subject))
                {
                    app.Subject = app.Body;
                }
            }
        }

        private void c1Schedule_MouseDown(object sender, MouseEventArgs e)
        {
            c1Calendar1.Schedule = (C1Schedule)sender;
        }

        private void c1Schedule1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            c1Calendar1.Schedule = c1Schedule2;
        }

        private void c1Schedule2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            c1Calendar1.Schedule = c1Schedule1;
        }
    }
}
