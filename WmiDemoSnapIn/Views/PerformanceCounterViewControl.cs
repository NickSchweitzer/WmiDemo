#region Using Directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheCodingMonkey.WmiDemo.SnapIn.Data;
using System.Diagnostics;

#endregion

namespace TheCodingMonkey.WmiDemo.SnapIn.Views
{
    public partial class PerformanceCounterViewControl : UserControl
    {
        public PerformanceCounterViewControl()
        {
            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.performanceChartControl1.AddCounter(new PerformanceCounter("Memory", "Available MBytes"), "Available Memory - {0} MBytes");
            this.performanceChartControl1.AddCounter(new PerformanceCounter("Processor", "% Processor Time", "_Total"), "Processor Time - {0:0.00}%");
        }
    }
}