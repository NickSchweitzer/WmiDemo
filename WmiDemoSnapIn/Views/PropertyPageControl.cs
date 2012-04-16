using System;
using System.Windows.Forms;

namespace TheCodingMonkey.WmiDemo.SnapIn.Views
{
    public class PropertyPageControl : UserControl
    {
        public virtual bool OnOK() { return true; }
        public virtual bool OnApply() { return true; }
    }
}