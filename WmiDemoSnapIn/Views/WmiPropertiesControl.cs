using System;
using System.Windows.Forms;

namespace TheCodingMonkey.WmiDemo.SnapIn.Views
{
    public partial class WmiPropertiesControl : PropertyPageControl
    {
        private Task _WmiObject = null;

        public WmiPropertiesControl(Task wmiObject)
        : this()
        {
            _WmiObject = wmiObject;
            _WmiObjectProperties.SelectedObject = wmiObject;
        }

        public WmiPropertiesControl()
        {
            InitializeComponent();
        }

        public override bool OnApply()
        {
            try
            {
                _WmiObject.CommitObject();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override bool OnOK()
        {
            return OnApply();
        }
    }
}