#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace TheCodingMonkey.WmiDemo.SnapIn.Data
{
    public class MaxSizeFilter : IFilter<PerformanceDataPoint>
    {
        TimeSpan length = TimeSpan.FromSeconds(10);

        #region IFilter<PerformanceDataPoint> Implementation

        public IList<PerformanceDataPoint> Filter(IList<PerformanceDataPoint> c)
        {
            if (c.Count == 0)
                return new List<PerformanceDataPoint>();

            DateTime end = c[c.Count - 1].Time;

            int startIndex = 0;
            for (int i = 0; i < c.Count; i++)
            {
                if (end - c[i].Time <= length)
                {
                    startIndex = i;
                    break;
                }
            }

            List<PerformanceDataPoint> res = new List<PerformanceDataPoint>(c.Count - startIndex);
            for (int i = startIndex; i < c.Count; i++)
            {
                res.Add(c[i]);
            }
            return res;
        }

        #endregion
    }

    public class FilterChain : IFilter<PerformanceDataPoint>
    {
        private readonly IFilter<PerformanceDataPoint>[] filters;
        public FilterChain(params IFilter<PerformanceDataPoint>[] filters)
        {
            this.filters = filters;
        }

        #region IFilter<PerformanceDataPoint> Implementation

        public IList<PerformanceDataPoint> Filter(IList<PerformanceDataPoint> c)
        {
            foreach (var filter in filters)
            {
                c = filter.Filter(c);
            }
            return c;
        }

        #endregion
    }

    public class AverageFilter : IFilter<PerformanceDataPoint>
    {
        private int number = 2;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        #region IFilter<PerformanceDataPoint> Implementation

        public IList<PerformanceDataPoint> Filter(IList<PerformanceDataPoint> c)
        {
            int num = number - 1;
            if (c.Count - num <= 0)
                return c;

            List<PerformanceDataPoint> res = new List<PerformanceDataPoint>(c.Count - num);
            for (int i = 0; i < c.Count - num; i++)
            {
                double doubleSum = 0;
                long ticksSum = 0;
                for (int j = i; j < i + number; j++)
                {
                    doubleSum += c[j].Value;
                    ticksSum += c[j].Time.Ticks / number;
                }
                doubleSum /= number;
                res.Add(new PerformanceDataPoint { Time = new DateTime(ticksSum), Value = doubleSum });
            }
            return res;
        }

        #endregion
    }
}