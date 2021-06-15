using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C1.C1Schedule;

namespace ControlExplorer.Schedule
{
    public partial class Grouping : C1DemoForm
    {
        public Grouping()
        {
            InitializeComponent();
            
        }

        private void c1CommandHolder1_CommandClick(object sender, C1.Win.C1Command.CommandClickEventArgs e)
        {
            if (e.Command == c1Command_Day)
            {
                //switch to day view
                c1Schedule1.ViewType = C1.Win.C1Schedule.ScheduleViewEnum.DayView;
                c1Command_Month.Checked = false;
                c1Command_Week.Checked = false;
                c1Command_Day.Checked = true;
                c1Command_FullWeek.Checked = false;
                c1Command_TimeLine.Checked = false;
            }
            else if (e.Command == c1Command_Week)
            {
                //switch to work week view
                c1Schedule1.ViewType = C1.Win.C1Schedule.ScheduleViewEnum.WorkWeekView;
                c1Command_Month.Checked = false;
                c1Command_Week.Checked = true;
                c1Command_Day.Checked = false;
                c1Command_FullWeek.Checked = false;
                c1Command_TimeLine.Checked = false;
            }
            else if (e.Command == c1Command_FullWeek)
            {
                //switch to full week view
                c1Schedule1.ViewType = C1.Win.C1Schedule.ScheduleViewEnum.WeekView;
                c1Command_Month.Checked = false;
                c1Command_Week.Checked = false;
                c1Command_Day.Checked = false;
                c1Command_FullWeek.Checked = true;
                c1Command_TimeLine.Checked = false;
            }
            else if (e.Command == c1Command_Month)
            {
                //switch to month view
                c1Schedule1.ViewType = C1.Win.C1Schedule.ScheduleViewEnum.MonthView;
                c1Command_Month.Checked = true;
                c1Command_Week.Checked = false;
                c1Command_Day.Checked = false;
                c1Command_FullWeek.Checked = false;
                c1Command_TimeLine.Checked = false;
            }
            else if (e.Command == c1Command_TimeLine)
            {
                //switch to month view
                c1Schedule1.ViewType = C1.Win.C1Schedule.ScheduleViewEnum.TimeLineView;
                c1Command_Month.Checked = false;
                c1Command_Week.Checked = false;
                c1Command_Day.Checked = false;
                c1Command_FullWeek.Checked = false;
                c1Command_TimeLine.Checked = true;
            }
            else if (e.Command == c1Command_GroupNone)
            {
                //turn off grouping
                c1Schedule1.GroupBy = "";
                c1Command_GroupNone.Checked = true;
                c1Command_GroupContact.Checked = false;
                c1Command_GroupCategory.Checked = false;
                c1Command_GroupResource.Checked = false;
            }
            else if (e.Command == c1Command_GroupCategory)
            {
                //group by category
                c1Schedule1.GroupBy = "Category";
                c1Command_GroupNone.Checked = false;
                c1Command_GroupContact.Checked = false;
                c1Command_GroupCategory.Checked = true;
                c1Command_GroupResource.Checked = false;
            }
            else if (e.Command == c1Command_GroupContact)
            {
                //group by contact
                c1Schedule1.GroupBy = "Contact";
                c1Command_GroupNone.Checked = false;
                c1Command_GroupContact.Checked = true;
                c1Command_GroupCategory.Checked = false;
                c1Command_GroupResource.Checked = false;
            }
            else if (e.Command == c1Command_GroupResource)
            {
                //group by resource
                c1Schedule1.GroupBy = "Resource";
                c1Command_GroupNone.Checked = false;
                c1Command_GroupContact.Checked = false;
                c1Command_GroupCategory.Checked = false;
                c1Command_GroupResource.Checked = true;
            }
        }

        Random rnd = new Random();
        string[] subjects = new string[] { "设计会议", "和VP午餐", "电话会议", "商业方案", "在家中工作", "网络直播", "市场营销会议", "销售会议", "案例研究", "财政计划", "头脑风暴会议", "点对点回顾", "桑达斯基项目计划", "年度目标回顾" };
        string[] locations = new string[] { "桑达斯基会议", "匹兹堡会议", "圣地亚哥会议", "会议房间", "办公室" };
        int[] durations = new int[] { 60, 60, 90, 120 };

        void CreateSampleData(int nAppts)
        {
            CreateContacts();
            CreateResources();
            for (int i = 0; i < nAppts; i++)
            {
                Appointment ap = new Appointment();
                ap.Subject = subjects[rnd.Next(0, subjects.Length - 1)];
                ap.Location = locations[rnd.Next(0, locations.Length - 1)];
                ap.Start = DateTime.Now.AddDays(rnd.Next(-3, 3)).AddHours(rnd.Next(-4, 4));
                ap.End = ap.Start.AddMinutes(durations[rnd.Next(0, durations.Length - 1)]);
                c1Schedule1.DataStorage.AppointmentStorage.Appointments.Add(ap);
                ap.Label = c1Schedule1.DataStorage.LabelStorage.Labels[rnd.Next(0, c1Schedule1.DataStorage.LabelStorage.Labels.Count - 1)];
                ap.Resources.Add((Resource)c1Schedule1.DataStorage.ResourceStorage.Resources[rnd.Next(0, c1Schedule1.DataStorage.ResourceStorage.Resources.Count - 1)]);
                ap.Categories.Add((Category)c1Schedule1.DataStorage.CategoryStorage.Categories[rnd.Next(0, c1Schedule1.DataStorage.CategoryStorage.Categories.Count - 1)]);
                ap.Links.Add((Contact)c1Schedule1.DataStorage.ContactStorage.Contacts[rnd.Next(0, c1Schedule1.DataStorage.ContactStorage.Contacts.Count - 1)]);
            }
        }

        void CreateContacts()
        {
            c1Schedule1.DataStorage.ContactStorage.Contacts.Add(new Contact() { Text = "马修" });
            c1Schedule1.DataStorage.ContactStorage.Contacts.Add(new Contact() { Text = "阿尔西亚" });
            c1Schedule1.DataStorage.ContactStorage.Contacts.Add(new Contact() { Text = "夏琳" });
            c1Schedule1.DataStorage.ContactStorage.Contacts.Add(new Contact() { Text = "杰西卡" });
            c1Schedule1.DataStorage.ContactStorage.Contacts.Add(new Contact() { Text = "艾米" });
        }

        void CreateResources()
        {
            c1Schedule1.DataStorage.ResourceStorage.Resources.Add(new Resource() { Text = "会议室 1" });
            c1Schedule1.DataStorage.ResourceStorage.Resources.Add(new Resource() { Text = "会议室 2" });
            c1Schedule1.DataStorage.ResourceStorage.Resources.Add(new Resource() { Text = "会议室 3" });

        }

        private void Grouping_Load(object sender, EventArgs e)
        {
            CreateSampleData(40);
            c1Schedule1.GroupBy = "Contact";
            c1Schedule1.Settings.FirstVisibleTime = DateTime.Now.TimeOfDay.Subtract(new TimeSpan(4, 0, 0));

            // add demo properties
            AddProperty("GroupPageSize", c1Schedule1);
            AddProperty("ShowEmptyGroupItem", c1Schedule1);
        }

    }
}
