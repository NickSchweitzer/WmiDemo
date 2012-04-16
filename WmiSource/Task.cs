using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;

using TheCodingMonkey.WmiDemo.Common;

namespace TheCodingMonkey.WmiDemo.Source
{
    public class Tasks : ObservableWmiCollection<Task>
    { }

    [ManagementEntity]
    public class Task : NotifyObject
    {
        private static int _nNextKey = 0;

        public static ICollection<Task> TaskList
        {
            get;
            set;
        }

        [ManagementBind]
        public static Task GetTaskById([ManagementName("TaskId")] int taskId)
        {
            return TaskList.First(searchTask => searchTask.TaskId == taskId);
        }

        public Task()
        {
            TaskId = _nNextKey++;
            Start = DateTime.Now;
            End = Start.AddMinutes(30);
        }

        [ManagementKey]
        public int TaskId
        {
            get;
            private set;
        }

        private string _strName;
        [ManagementConfiguration]
        public string Name
        {
            get { return _strName; }
            set
            {
                if (_strName != value)
                {
                    _strName = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        private DateTime _dtStart;
        [ManagementConfiguration]
        public DateTime Start
        {
            get { return _dtStart; }
            set
            {
                if (_dtStart != value)
                {
                    _dtStart = value;
                    RaisePropertyChanged("Start");
                    RaisePropertyChanged("Duration");
                }
            }
        }

        private DateTime _dtEnd;
        [ManagementConfiguration]
        public DateTime End
        {
            get { return _dtEnd; }
            set
            {
                if (_dtEnd != value)
                {
                    _dtEnd = value;
                    RaisePropertyChanged("End");
                    RaisePropertyChanged("Duration");
                }
            }
        }

        private bool _bCompleted;
        [ManagementConfiguration]
        public bool Completed
        {
            get { return _bCompleted; }
            set
            {
                if (_bCompleted != value)
                {
                    _bCompleted = value;
                    RaisePropertyChanged("Completed");
                }
            }
        }

        [ManagementProbe]
        public TimeSpan Duration
        {
            get
            {
                if (End != null && Start != null)
                    return End.Subtract(Start);
                else
                    return TimeSpan.Zero;
            }
        }

        private int _nReminders = 0;
        [ManagementProbe]
        public int Reminders
        {
            get { return _nReminders; }
            private set 
            {
                if (_nReminders != value)
                {
                    _nReminders = value;
                    RaisePropertyChanged("Reminders");
                }
            }
        }

        [ManagementTask]
        public virtual void Remind()
        {
            Reminders++;
            Reminder remind = new Reminder(this);
            remind.Fire();
        }

        public override string ToString()
        {
            return string.Format("{0} (Duration: {1})", Name, Duration);
        }
    }
}