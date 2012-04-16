using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Management.Instrumentation;
using System.ComponentModel;

using TheCodingMonkey.WmiDemo.Common;

namespace TheCodingMonkey.WmiDemo.Source
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Task.TaskList = (ICollection<Task>)FindResource("TodoList");
            ListCollectionView view = (ListCollectionView)CollectionViewSource.GetDefaultView(Task.TaskList);
            view.CustomSort = new TaskSorter();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // BUG ALERT! YOU MUST DO THIS!!!
            InstrumentationManager.UnregisterType(typeof(Task));
            InstrumentationManager.UnregisterType(typeof(HighPriorityTask));
            base.OnClosing(e);
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            Task newTask = new Task();
            Task.TaskList.Add(newTask);
            ICollectionView view = CollectionViewSource.GetDefaultView(Task.TaskList);
            view.MoveCurrentTo(newTask);
            _txtName.Focus();
        }

        private void RemTask_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(Task.TaskList);
            Task remTask = (Task)view.CurrentItem;
            Task.TaskList.Remove(remTask);
        }

        private void Reminder_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(Task.TaskList);
            Task remindTask = (Task)view.CurrentItem;
            remindTask.Remind();
        }
    }
}