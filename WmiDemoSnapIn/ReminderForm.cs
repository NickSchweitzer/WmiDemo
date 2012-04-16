#region Using Directives

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TheCodingMonkey.WmiDemo.SnapIn.Properties;

#endregion

namespace TheCodingMonkey.WmiDemo.SnapIn
{
    public partial class ReminderForm : Form
    {
        public ReminderForm(Reminder remind)
        : this()
        {
            if (remind != null)
            {
                _txtTask.Text = remind.Text;
                _txtDue.Text = remind.TimeLeft.TotalMinutes.ToString();
                _imgLate.Image = remind.Late ? Resources.Warning : Resources.Info;
            }
        }

        public ReminderForm()
        {
            InitializeComponent();
        }
    }
}