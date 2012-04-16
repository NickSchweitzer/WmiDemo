#region Using Directives

using System;
using System.Collections.Generic;

#endregion

namespace TheCodingMonkey.WmiDemo.SnapIn.Data
{
    public interface IFilter<T>
    {
        IList<T> Filter(IList<T> c);
    }
}