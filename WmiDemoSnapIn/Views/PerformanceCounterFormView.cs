#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MMC = Microsoft.ManagementConsole;
using Microsoft.ManagementConsole;

#endregion

namespace TheCodingMonkey.WmiDemo.SnapIn.Views
{
    public class PerformanceCounterFormView : FormView
    {
        protected override void OnInitialize(AsyncStatus status)
        {
            base.OnInitialize(status);
            Control.Dock = System.Windows.Forms.DockStyle.Fill;
        }
    }
}