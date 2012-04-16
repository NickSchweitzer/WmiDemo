using System;

namespace TheCodingMonkey.WmiDemo.Common
{
    public static class WmiConstants
    {
        public const string TaskCreatedQuery = "SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Task'";
        public const string TaskChangedQuery = "SELECT * FROM __InstanceModificationEvent WITHIN 2 WHERE PreviousInstance ISA 'Task'";
        public const string TaskRemovedQuery = "SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Task'";

        public const string ReminderQuery = "SELECT * FROM Reminder WITHIN 2";

        public const string Namespace = "root\\TheCodingMonkey\\WmiDemo";
    }
}