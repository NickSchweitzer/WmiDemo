#region Using Directives

using System;
using System.Drawing;
using System.Management;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MMC = Microsoft.ManagementConsole;
using Microsoft.ManagementConsole;
using Microsoft.ManagementConsole.Advanced;

using TheCodingMonkey.WmiDemo.Common;
using TheCodingMonkey.WmiDemo.SnapIn.Properties;

#endregion

namespace TheCodingMonkey.WmiDemo.SnapIn
{
    [SnapInSettings("{EA9200CF-573E-42de-9F19-06C65ED8EF9B}", 
        DisplayName = "WMI Demo Snap-In",
        Description = "ALT.NET WMI Demonstration Snap-In",
        Vendor = "The Coding Monkey")]
    [ExtendsNodeType("{476e6449-aaff-11d0-b944-00c04fd8d5b0}")]
    public class WmiDemoSnapIn : NamespaceExtension
    {
        #region Private Data

        private ScopeNode _snapInNode;
        private ManagementEventWatcher ReminderWatcher;

        #endregion

        #region Construction

        public WmiDemoSnapIn()
        {
            // Images only need to be initialized once, and does not depend on the computer we're attached to
            // so this can be done in the constructor of the SnapIn itself.
            InitializeImages();

            // Have to register to listen to this event, otherwise won't be notified when the user
            // selects to monitor a different computer other than the Local Machine
            PrimaryNode.SharedData.Add(new SharedDataItem(SnapInShared.MachineName));
        }
        
        /// <summary>Initializes the nodes and the views attached to each node in the SnapIn tree.</summary>
        private void InitializeNodes()
        {
            // Primary Node for the SnapIn. Create it, and then add it to the Parent Node which belongs
            // to Computer Management
            _snapInNode = new ScopeNode {
                DisplayName = "WMI Demo Snap-In",
                ImageIndex = SnapInShared.WmiDemoImage,
                SelectedImageIndex = SnapInShared.WmiDemoImage };

            PrimaryNode.Children.Add(_snapInNode);
            
            // Node which contains a report view of all the tasks that are in the system
            ScopeNode taskListNode = new ScopeNode { 
                DisplayName = "Tasks", 
                ImageIndex = SnapInShared.TaskImage, 
                SelectedImageIndex = SnapInShared.TaskImage };
            _snapInNode.Children.Add(taskListNode);

            // View Description for the Task List
            MmcListViewDescription scheduledLvd = new MmcListViewDescription { 
                DisplayName = "Scheduled Task List", 
                ViewType = typeof(Views.TaskListView), 
                Options = MmcListViewOptions.ExcludeScopeNodes };

            taskListNode.ViewDescriptions.Add(scheduledLvd);
            taskListNode.ViewDescriptions.DefaultIndex = 0;

            // Node for the Web site Link
            ScopeNode htmlNode = new ScopeNode { 
                DisplayName = "Web Site", 
                ImageIndex = SnapInShared.WebsiteImage, 
                SelectedImageIndex = SnapInShared.WebsiteImage };
            _snapInNode.Children.Add(htmlNode);

            HtmlViewDescription htmlDesc = new HtmlViewDescription { DisplayName = "The Coding Monkey", Url = new Uri("http://www.thecodingmonkey.net") };

            // attach the view and set it as the default to show
            htmlNode.ViewDescriptions.Add(htmlDesc);
            htmlNode.ViewDescriptions.DefaultIndex = 0;

            // Node for the "Performance" Pane
            ScopeNode perfNode = new ScopeNode { 
                DisplayName = "Performance", 
                ImageIndex = SnapInShared.Performance, 
                SelectedImageIndex = SnapInShared.Performance };
            _snapInNode.Children.Add(perfNode);

            FormViewDescription perfFvd = new FormViewDescription { 
                DisplayName = "Performance", 
                ViewType = typeof(Views.PerformanceCounterFormView), 
                ControlType = typeof(Views.PerformanceCounterViewControl) };

            perfNode.ViewDescriptions.Add(perfFvd);
            perfNode.ViewDescriptions.DefaultIndex = 0;
        }

        /// <summary>Adds all the resource images to the SnapIn built in Image List so can reference
        /// from different parts of the SnapIn universally.</summary>
        private void InitializeImages()
        {
            LargeImages.Add(Resources.WmiDemo);
            SmallImages.Add(Resources.WmiDemo);

            LargeImages.Add(Resources.Website);
            SmallImages.Add(Resources.Website);

            LargeImages.Add(Resources.Task);
            SmallImages.Add(Resources.Task);

            LargeImages.Add(Resources.Refresh);
            SmallImages.Add(Resources.Refresh);

            LargeImages.Add(Resources.Completed);
            SmallImages.Add(Resources.Completed);

            LargeImages.Add(Resources.NotCompleted);
            SmallImages.Add(Resources.NotCompleted);

            LargeImages.Add(Resources.Performance);
            SmallImages.Add(Resources.Performance);
        }

        /// <summary>Create the WMI Watcher for the Reminder event.</summary>
        private void InitializeWatchers()
        {
            ReminderWatcher = new ManagementEventWatcher(Task.StaticScope, 
                new WqlEventQuery(WmiConstants.ReminderQuery));
            ReminderWatcher.EventArrived += ReminderWatcher_EventArrived;
            ReminderWatcher.Start();
        }

        #endregion

        #region Event Handlers

        private void ReminderWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new System.Action<ManagementBaseObject>(PopUpReminder), new object[] { e.NewEvent });
            else
                PopUpReminder(e.NewEvent);

        }

        private void PopUpReminder(ManagementBaseObject mgmtObj)
        {
            using (Reminder remind = new Reminder(mgmtObj))
            {
                using (ReminderForm dlg = new ReminderForm(remind))
                {
                    Console.ShowDialog(dlg);
                }
            }
        }

        #endregion

        #region Public Properties

        private string _machineName = string.Empty;

        /// <summary>Changes the machine name that the SnapIn is showing data for.</summary>
        /// <<remarks>This comes from a COM buffer, so it's null terminated and a little old fashioned 
        /// manipulation must be performed to get the correct string.</remarks>
        public string MachineName
        {
            get { return _machineName; }
            set
            {
                _machineName = value;

                // Find first null terminated string in buffer. 
                if (_machineName.IndexOf('\0') <= 0)
                    _machineName = String.Empty;
                else
                    _machineName = _machineName.Substring(0, _machineName.IndexOf('\0'));

                if (string.IsNullOrEmpty(_machineName))
                    _machineName = ".";

                // Change the static scope on the WMI classes we've created so that we query the right computer
                ManagementPath wmiDemoPath = new ManagementPath { NamespacePath = WmiConstants.Namespace, Server = _machineName };
                Task.StaticScope = new ManagementScope(wmiDemoPath);
            }
        }

        #endregion

        #region Override Methods

        protected override void OnInitialize()
        {
            MachineName = Encoding.Unicode.GetString(PrimaryNode.SharedData.GetItem(SnapInShared.MachineName).GetData());

            // PERFORM DETECTION HERE. If don't detect your service, appliction or WMI namespace, then can
            // return here instead of calling the remaining initialize methods so that your node won't
            // appear in the Computer Management list

            InitializeNodes();
            InitializeWatchers();
        }

        protected override void OnShutdown(AsyncStatus status)
        {
            // Stop the watcher. This is necessary, otherwise will get a funky exception on shutdown
            if (ReminderWatcher != null)
                ReminderWatcher.Stop();

            base.OnShutdown(status);
        }

        /// <summary>This will get called when the user chooses to monitor a different computer other than
        /// the Local Machine.</summary>
        protected override void OnSharedDataChanged(SharedDataItem sharedDataItem)
        {
            // If the machine name has changed, Update the Local Name. OnInitialize will get called again!
            if (sharedDataItem.ClipboardFormatId == SnapInShared.MachineName)
            {
                MachineName = Encoding.Unicode.GetString(sharedDataItem.GetData());
            }
        }

        #endregion
    }
}