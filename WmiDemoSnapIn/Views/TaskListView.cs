#region Using Directives

using System;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.ManagementConsole;
using MMC = Microsoft.ManagementConsole;

using TheCodingMonkey.WmiDemo.Common;

#endregion

namespace TheCodingMonkey.WmiDemo.SnapIn.Views
{
    public class TaskListView : MmcListView
    {
        #region Private Data

        private MmcListViewColumn NameColumn;
        private MmcListViewColumn TaskIdColumn;
        private MmcListViewColumn StartColumn;
        private MmcListViewColumn EndColumn;
        private MmcListViewColumn DurationColumn;
        private MmcListViewColumn CompletedColumn;

        ManagementEventWatcher CreatedWatcher;
        ManagementEventWatcher ChangedWatcher;
        ManagementEventWatcher RemovedWatcher;

        #endregion

        #region Override Methods

        protected override void OnInitialize(AsyncStatus status)
        {
            // This is a default column which already exists when the control is created.
            NameColumn = Columns[0];
            NameColumn.Title = "Name";
            NameColumn.SetWidth(150);

            TaskIdColumn = new MmcListViewColumn("Task ID", -1);
            StartColumn = new MmcListViewColumn("Start Time", -1);
            EndColumn = new MmcListViewColumn("End Time", -1);
            DurationColumn = new MmcListViewColumn("Duration", -1);
            CompletedColumn = new MmcListViewColumn("Completed", -1);

            Columns.AddRange(new MmcListViewColumn[] { TaskIdColumn, StartColumn, EndColumn, 
                DurationColumn, CompletedColumn });

            Refresh();

            MMC.Action RefreshAction = new MMC.Action("Refresh",
                "Refresh the Task List", SnapInShared.Refresh, "Refresh");
            ActionsPaneItems.Add(RefreshAction);

            Mode = MmcListViewMode.Report;

            InitializeWatchers();

            base.OnInitialize(status);
        }

        protected override void OnShutdown(SyncStatus status)
        {
            CreatedWatcher.Stop();
            ChangedWatcher.Stop();
            RemovedWatcher.Stop();

            base.OnShutdown(status);
        }

        protected override void OnAction(MMC.Action action, AsyncStatus status)
        {
            string actionString = action.Tag as string;
            if (actionString != null)
            {
                switch (actionString)
                {
                    case "Refresh":
                        Refresh();
                        break;
                }
            }
            base.OnAction(action, status);
        }

        protected override void OnSelectionChanged(SyncStatus status)
        {
            int selectedCount = SelectedNodes.Count;
            if (selectedCount == 0)
            {
                SelectionData.Clear();
                SelectionData.ActionsPaneItems.Clear();
            }
            else
            {
                SelectionData.Update(SelectedNodes[0], selectedCount > 1, null, null);
                SelectionData.ActionsPaneItems.Clear();
                SelectionData.ActionsPaneItems.AddRange(new ActionsPaneItem[]
                {
                    new MMC.Action("Properties", "Properties", -1, "Properties"),
                    new MMC.Action("Reminder", "Fire Reminder for this Task", -1, "Reminder")
                } );
            }
        }

        protected override void OnSelectionAction(MMC.Action action, AsyncStatus status)
        {
            string actionString = action.Tag as string;
            if (actionString != null)
            {
                switch (actionString)
                {
                    case "Properties":
                        SelectionData.ShowPropertySheet("Properties", true);
                        break;
                    case "Reminder":
                        FireReminder();
                        break;
                }
            }
        }

        protected override void OnAddPropertyPages(PropertyPageCollection propertyPageCollection)
        {
            if (SelectedNodes.Count > 0)
            {
                Task wmiTask = SelectedNodes[0].Tag as Task;

                WmiPropertiesControl propertiesControl = new WmiPropertiesControl(wmiTask);
                var propertiesPage = new DetailsPropertyPage<WmiPropertiesControl>(
                    "Task", propertiesControl);
                propertyPageCollection.Add(propertiesPage);
            }
        }

        #endregion

        #region Private Methods

        private void FireReminder()
        {
            Task wmiTask = SelectedNodes[0].Tag as Task;
            SnapIn.BeginInvoke(new System.Action(wmiTask.Remind));
            //wmiTask.Remind();
        }

        private void InitializeWatchers()
        {
            CreatedWatcher = new ManagementEventWatcher(Task.StaticScope, new WqlEventQuery(WmiConstants.TaskCreatedQuery));
            ChangedWatcher = new ManagementEventWatcher(Task.StaticScope, new WqlEventQuery(WmiConstants.TaskChangedQuery));
            RemovedWatcher = new ManagementEventWatcher(Task.StaticScope, new WqlEventQuery(WmiConstants.TaskRemovedQuery));

            CreatedWatcher.EventArrived += TaskList_EventArrived;
            ChangedWatcher.EventArrived += TaskList_EventArrived;
            RemovedWatcher.EventArrived += TaskList_EventArrived;

            CreatedWatcher.Start();
            ChangedWatcher.Start();
            RemovedWatcher.Start();
        }

        private void TaskList_EventArrived(object sender, EventArrivedEventArgs e)
        {
            if (SnapIn.InvokeRequired)
                SnapIn.Invoke(new System.Action(Refresh));
            else
                Refresh();
        }

        private void Refresh()
        {
            ResultNodes.Clear();

            foreach (Task wmiTask in Task.GetInstances())
            {
                ResultNode taskNode = new ResultNode();
                taskNode.DisplayName = wmiTask.Name;
                taskNode.ImageIndex = GetTaskIcon(wmiTask.Completed);

                taskNode.SubItemDisplayNames.AddRange(new string[] 
                { 
                    wmiTask.TaskId.ToString(), 
                    SnapInShared.FormatDateTime(wmiTask.Start), 
                    SnapInShared.FormatDateTime(wmiTask.End), 
                    SnapInShared.FormatTimeSpan(wmiTask.Duration),
                    wmiTask.Completed.ToString()
                });

                taskNode.Tag = wmiTask;
                ResultNodes.Add(taskNode);
            }
        }

        protected static int GetTaskIcon(bool completed)
        {
            return completed ? SnapInShared.Completed : SnapInShared.NotCompleted;
        }

        #endregion
    }
}