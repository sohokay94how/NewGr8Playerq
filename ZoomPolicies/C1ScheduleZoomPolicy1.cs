using C1.Framework;
using C1.Win.C1Schedule;
using C1.Win.TouchToolKit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControlExplorer.ZoomPolicies
{
    public class C1CalendarZoomPolicy : ZoomPolicy
    {
        public override Type TargetType
        {
            get { return typeof(C1Calendar); }
        }

        public override void ZoomBounds(Control control, ZoomBoundsInfo infos)
        {
            var size = control.MaximumSize;
            // Change the MaxSize to make sure the Size can be changed.
            control.MaximumSize = new Size(control.Width, control.Height);

            base.ZoomBounds(control, infos);

            control.MaximumSize = infos.Zoom(size);

            control.Refresh();
        }

        public override void ZoomFont(Control control, ZoomFontInfo infos)
        {
            C1Calendar calendar = control as C1Calendar;
            if (calendar.Theme != null)
            {
                calendar.Theme.BaseFont = infos.Zoom(calendar.Theme.BaseFont);
            }
            base.ZoomFont(control, infos);
        }
    }

    public class C1ScheduleZoomPolicy : ZoomPolicy
    {
        public override Type TargetType
        {
            get { return typeof(C1Schedule); }
        }

        public override void ZoomBounds(Control control, ZoomBoundsInfo infos)
        {
            base.ZoomBounds(control, infos);
            C1Schedule schedule = control as C1Schedule;
            if (schedule.AppointmentHeight > 0)
            {
                schedule.AppointmentHeight = infos.Zoom(schedule.AppointmentHeight);
            }
            control.Refresh();
        }

        public override void ZoomFont(Control control, ZoomFontInfo infos)
        {
            C1Schedule schedule = control as C1Schedule;
            if (schedule.Theme != null)
            {
                schedule.Theme.BaseFont = infos.Zoom(schedule.Theme.BaseFont);
                if (schedule.Theme.TimeRulerMinutesFont != null && !object.ReferenceEquals(schedule.Theme.TimeRulerMinutesFont, schedule.Theme.BaseFont))
                {
                    schedule.Theme.TimeRulerMinutesFont = infos.Zoom(schedule.Theme.TimeRulerMinutesFont);
                }

            }
            base.ZoomFont(control, infos);
        }
    }
}

