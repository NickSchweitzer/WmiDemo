using System;
using System.Management.Instrumentation;

namespace TheCodingMonkey.WmiDemo.Source
{
    /// <summary>Sample Custom WMI Event to Remind a user of a Task. Because this derives from BaseEvent, all you
    /// have to do is call <see cref="Fire"/>Fire</see> to fire the event in the WMI repository.</summary>
    public class Reminder : BaseEvent
    {
        public Reminder(Task task)
        {
            Task = task;
        }

        /// <summary>Used on for Reference. Events use the "Old Style" WMI system, so you can't reference
        /// objects in an Event like you can in a normal instrumented class.</summary>
        [IgnoreMember]
        public Task Task
        {
            get;
            private set;
        }

        /// <summary>Time left before the Task starts.</summary>
        public TimeSpan TimeLeft
        {
            get
            {
                DateTime now = DateTime.Now;
                if (now < Task.Start)
                    return Task.Start.Subtract(now);
                else
                    return TimeSpan.Zero;
            }
        }

        /// <summary>Task Name</summary>
        public string Text
        {
            get { return Task.Name; }
        }

        /// <summary>Boolean indicating whether the Task has already started or not.</summary>
        public bool Late
        {
            get { return Task.Start.CompareTo(DateTime.Now) < 0; }
        }
    }
}