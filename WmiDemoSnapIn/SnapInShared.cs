using System;

namespace TheCodingMonkey.WmiDemo.SnapIn
{
    public static class SnapInShared
    {
        public const string MachineName = "MMC_SNAPIN_MACHINE_NAME";

        // Image List Constants that are used by the SnapIn. These constant numbers are highly dependent
        // on the order they are added to the list in the InitializeImages() method in the main SnapIn class.
        public const int WmiDemoImage = 0;
        public const int WebsiteImage = 1;
        public const int TaskImage = 2;
        public const int Refresh = 3;
        public const int Completed = 4;
        public const int NotCompleted = 5;
        public const int Performance = 6;

        /// <summary>Helper method for formatting dates which properly handles edge case dates.</summary>
        public static string FormatDateTime(DateTime dt)
        {
            if (dt == DateTime.MinValue || dt.Year == 9999)
                return string.Empty;
            else
                return dt.ToString();
        }

        /// <summary>Helper method for formatting time spans which properly handles edge case time spans.</summary>
        public static string FormatTimeSpan(TimeSpan ts)
        {
            if (ts == TimeSpan.Zero)
                return string.Empty;
            else
                return ts.ToString();
        }
    }
}