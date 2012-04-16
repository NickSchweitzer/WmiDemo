using System;
using System.Windows;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Management.Instrumentation;

namespace TheCodingMonkey.WmiDemo.Common
{
    public class ObservableWmiCollection<T> : ObservableCollection<T>
    {
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (!IsInDesignMode)
            {
                if (args.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (object newObj in args.NewItems)
                        InstrumentationManager.Publish(newObj);
                }
                else if (args.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (object remObj in args.OldItems)
                        InstrumentationManager.Revoke(remObj);
                }
            }
            base.OnCollectionChanged(args);
        }

        private static bool IsInDesignMode
        {
            get { return (bool)DependencyPropertyDescriptor.FromProperty(DesignerProperties.IsInDesignModeProperty, typeof(FrameworkElement)).Metadata.DefaultValue; }
        }
    }
}