using System;
using System.Management.Instrumentation;

namespace TheCodingMonkey.WmiDemo.Source
{
    [ManagementEntity]
    public class HighPriorityTask : Task
    {
        [ManagementProbe]
        public bool Emergency
        {
            get { return true; }
        }
    }
}