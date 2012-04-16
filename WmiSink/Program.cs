#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

using TheCodingMonkey.WmiDemo.Common;

#endregion

namespace TheCodingMonkey.WmiDemo.Sink
{
    class Program
    {
        private static Dictionary<int, ManagementBaseObject> _objectCache = new Dictionary<int, ManagementBaseObject>();

        static void Main(string[] args)
        {
            var scope = new ManagementScope();
            scope.Path.NamespacePath = WmiConstants.Namespace;

            var createdWatcher = new ManagementEventWatcher(scope, new WqlEventQuery(WmiConstants.TaskCreatedQuery));
            var changedWatcher = new ManagementEventWatcher(scope, new WqlEventQuery(WmiConstants.TaskChangedQuery));
            var removedWatcher = new ManagementEventWatcher(scope, new WqlEventQuery(WmiConstants.TaskRemovedQuery));

            createdWatcher.EventArrived += ObjectCreated_EventArrived;
            changedWatcher.EventArrived += ObjectChanged_EventArrived;
            removedWatcher.EventArrived += ObjectRemoved_EventArrived;

            try
            {
                createdWatcher.Start();
                changedWatcher.Start();
                removedWatcher.Start();

                Console.WriteLine("Press Any Key to Exit");
                Console.WriteLine();
                Console.Read();
            }
            finally
            {
                if (createdWatcher != null)
                    createdWatcher.Stop();

                if (changedWatcher != null)
                    changedWatcher.Stop();

                if (removedWatcher != null)
                    removedWatcher.Stop();
            }
        }

        private static void ObjectCreated_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject newObj = GetEventTarget(e);
            DumpObjectProperties(newObj);

            int key = GetKey(newObj);
            _objectCache.Add(key, newObj);
        }

        private static void ObjectChanged_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject changeObj = GetEventTarget(e);
            int key = GetKey(changeObj);
            ManagementBaseObject oldObj = _objectCache[key];

            Console.WriteLine("Object {0} Changed with TaskId {1}", changeObj.ClassPath, key);
            Console.WriteLine();
            Console.WriteLine("Changed Properties");
            Console.WriteLine("------------------");

            foreach (var property in GetChangedProperties(oldObj, changeObj))
                Console.WriteLine(string.Format("{0}: {1}", property.Name, property.Value));

            Console.WriteLine();

            _objectCache[key] = changeObj;
        }

        private static void ObjectRemoved_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject remObj = GetEventTarget(e);
            int key = GetKey(remObj);
            Console.WriteLine("Removing {0} with TaskId {1}", remObj.ClassPath, key);
            Console.WriteLine();
            _objectCache.Remove(key);
        }

        private static int GetKey(ManagementBaseObject obj)
        {
            return Convert.ToInt32(obj.Properties["TaskId"].Value);
        }

        private static ManagementBaseObject GetEventTarget(EventArrivedEventArgs e)
        {
            return (ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value;
        }

        private static IEnumerable<PropertyData> GetChangedProperties(ManagementBaseObject oldObj, ManagementBaseObject changeObj)
        {
            List<PropertyData> changedProperties = new List<PropertyData>();
            foreach (var oldProperty in oldObj.Properties)
            {
                PropertyData changeProperty = changeObj.Properties[oldProperty.Name];

                string changeValue = changeProperty.Value == null ? string.Empty : changeProperty.Value.ToString();
                string oldValue = oldProperty.Value == null ? string.Empty : oldProperty.Value.ToString();

                if (changeValue != oldValue)
                    changedProperties.Add(changeProperty);
            }

            return changedProperties;
        }

        private static void DumpObjectProperties(ManagementBaseObject newObj)
        {
            Console.WriteLine(string.Format("New Object Class Path: {0}", newObj.ClassPath));
            Console.WriteLine();
            Console.WriteLine("Properties");
            Console.WriteLine("----------");

            foreach (var property in newObj.Properties)
            {
                string decorator = string.Empty;
                try
                {
                    QualifierData qual = property.Qualifiers["key"];
                    bool isKey = Convert.ToBoolean(qual.Value);
                    if (isKey)
                        decorator = "(Key)";
                }
                catch (ManagementException) { }

                Console.WriteLine(string.Format("{0}: {1} {2}", property.Name, property.Value, decorator));
            }
            Console.WriteLine();
        }
    }
}