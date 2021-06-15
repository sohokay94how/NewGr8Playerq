using C1.Win.C1Ribbon;
using C1.Win.TouchToolKit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ControlExplorer.ZoomPolicies
{
    public class C1RibbonZoomPolicy : NoZoomFontZoomPolicy
    {
        public override Type TargetType
        {
            get { return typeof(C1Ribbon); }
        }

        public override bool CanZoom(System.Windows.Forms.Control control)
        {
            return false;
        }

        public override bool CanZoomChildren(System.Windows.Forms.Control control)
        {
            return false;
        }
    }


    public class C1StatusBarZoomPolicy : NoZoomFontZoomPolicy
    {
        public override Type TargetType
        {
            get { return typeof(C1StatusBar); }
        }

        public override bool CanZoom(System.Windows.Forms.Control control)
        {
            return false;
        }

        public override bool CanZoomChildren(System.Windows.Forms.Control control)
        {
            return false;
        }
    }
}

