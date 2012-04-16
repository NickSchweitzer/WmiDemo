#region Using Directives

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Threading;

using Microsoft.Research.DynamicDataDisplay.Common;
using Microsoft.Research.DynamicDataDisplay;

#endregion

namespace TheCodingMonkey.WmiDemo.SnapIn.Data
{
    public class PerformanceDataPoint
    {
        public DateTime Time { get; set; }
        public double Value { get; set; }
    }

    public class PerformanceData : RingArray<PerformanceDataPoint>
    {
        #region Private Data

        private PerformanceCounter counter;

        #endregion

        #region Construction

        public PerformanceData(string categoryName, string counterName) 
        : this(new PerformanceCounter(categoryName, counterName)) 
        { }

        public PerformanceData(string categoryName, string counterName, string instanceName)
        :this(new PerformanceCounter(categoryName, counterName, instanceName))
        { }

        public PerformanceData(PerformanceCounter counter)
        : base(200)
        {
            if (counter == null)
                throw new ArgumentNullException("counter");

            this.counter = counter;
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        #endregion

        #region Public Properites

        public string DisplayFormat
        {
            get;
            set;
        }

        public string Name
        {
            get { return counter.CounterName; }
        }

        public string Category
        {
            get { return counter.CategoryName; }
        }

        #endregion

        #region Timer Code

        private void OnTimerTick(object sender, EventArgs e)
        {
            var newInfo = new PerformanceDataPoint { Time = DateTime.Now, Value = counter.NextValue() };
            this.Add(newInfo);

            Debug.WriteLine(String.Format("{0}.{1}: {2}", newInfo.Time.Second, newInfo.Time.Millisecond, newInfo.Value));
        }

        private TimeSpan updateInterval = TimeSpan.FromMilliseconds(500);
        public TimeSpan UpdateInterval
        {
            get { return updateInterval; }
            set
            {
                updateInterval = value;
                timer.Interval = updateInterval;
            }
        }

        private readonly DispatcherTimer timer = new DispatcherTimer();

        public void Run()
        {
            timer.Interval = updateInterval;
            timer.IsEnabled = true;
        }

        public void Pause()
        {
            timer.IsEnabled = false;
        }

        #endregion
    }
}