using System;
using System.ComponentModel;
using System.Management.Instrumentation;

namespace TheCodingMonkey.WmiDemo.Common
{
    public class WmiBindingList<T> : BindingList<T>
    {
        public WmiBindingList()
        : this(null)
        { }
        
        public WmiBindingList(ISite site)
        {
            Site = site;
            AllowNew = true;
            AllowRemove = true;
            AllowEdit = true;
            RaiseListChangedEvents = true;
        }

        private ISite Site
        {
            get;
            set;
        }

        protected override void RemoveItem(int index)
        {
            InstrumentationManager.Revoke(Items[index]);
            base.RemoveItem(index);
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (Site == null || !Site.DesignMode)
            {
                if (e.ListChangedType == ListChangedType.ItemAdded)
                    InstrumentationManager.Publish(Items[e.NewIndex]);
            }
        }
    }
}