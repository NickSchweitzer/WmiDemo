#region Using Directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.ComponentModel;

using System.Management.Instrumentation;
using TheCodingMonkey.WmiDemo.Common;

#endregion

namespace TheCodingMonkey.WmiDemo.Source
{
    public class Tasks : WmiBindingList<Task>
    {
        public Tasks(ISite site) : base(site)
        {
        }
    }
}