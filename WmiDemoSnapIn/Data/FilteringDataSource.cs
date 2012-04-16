#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections;

#endregion

namespace TheCodingMonkey.WmiDemo.SnapIn.Data
{
    public sealed class FilteringDataSource<T> : IEnumerable<T>, INotifyCollectionChanged
    {
        #region Private Data

        private readonly IList<T> _Collection;
        private readonly IFilter<T> filter;

        #endregion

        #region Construction

        public FilteringDataSource(IList<T> collection, IFilter<T> filter)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");
            if (filter == null)
                throw new ArgumentNullException("filter");
            
            _Collection = collection;

            INotifyCollectionChanged observableCollection = collection as INotifyCollectionChanged;
            if (observableCollection != null)
                observableCollection.CollectionChanged += collection_CollectionChanged;

            this.filter = filter;
        }

        #endregion

        #region Event Handlers

        void collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaiseCollectionChanged();
        }

        #endregion

        #region IEnumerable<T> Implementation

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)filter.Filter(_Collection)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Events

        private void RaiseCollectionChanged()
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        #endregion
    }
}