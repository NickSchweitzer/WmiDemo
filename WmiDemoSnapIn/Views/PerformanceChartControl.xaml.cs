#region Using Directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay.Charts;

using TheCodingMonkey.WmiDemo.SnapIn.Data;
using System.Diagnostics;

#endregion

namespace TheCodingMonkey.WmiDemo.SnapIn.Views
{
    public partial class PerformanceChartControl : UserControl
    {
        #region Construction

        public PerformanceChartControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        public void AddCounter(PerformanceCounter counter, string format)
        {
            PerformanceData data = new PerformanceData(counter);
            data.DisplayFormat = format;

            var filteredData = new FilteringDataSource<PerformanceDataPoint>(data, new MaxSizeFilter());
            var ds = new EnumerableDataSource<PerformanceDataPoint>(filteredData);
            ds.SetXMapping(pi => pi.Time.TimeOfDay.TotalSeconds);
            ds.SetYMapping(pi => pi.Value);

            LineGraph graph = plotter.AddLineGraph(ds, 2.0, String.Format("{0} - {1}", data.Category, data.Name));
            graph.DataChanged += graph_DataChanged;
            graph.Tag = data;
        }

        #endregion

        #region Event Handlers

        private void graph_DataChanged(object sender, EventArgs e)
        {
            LineGraph graph = (LineGraph)sender;
            PerformanceData data = (PerformanceData)graph.Tag;
            double value = graph.DataSource.GetPoints().LastOrDefault().Y;
            graph.Description = new PenDescription(string.Format(data.DisplayFormat, value));
        }

        #endregion
    }
}