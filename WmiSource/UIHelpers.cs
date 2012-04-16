using System;
using System.Windows.Data;
using System.Windows.Media;
using System.Collections;

using TheCodingMonkey.WmiDemo.Common;

namespace TheCodingMonkey.WmiDemo.Source
{
    /// <summary>Used for WPF Binding to Color the Foreground Text of a List Item to Red if a Task is Not Completed.</summary>
    public class CompletedToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(Brush))
                return null;

            bool completed = false;
            bool valid = bool.TryParse(value.ToString(), out completed);
            return completed ? Brushes.Black : Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>Used to sort the Tasks in a list box by their TaskId</summary>
    public class TaskSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            Task left = (Task)x;
            Task right = (Task)y;
            return left.TaskId.CompareTo(right.TaskId);
        }
    }
}