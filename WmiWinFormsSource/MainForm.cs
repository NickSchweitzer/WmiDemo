using System;
using System.Windows.Forms;
using System.Drawing;
using System.Management.Instrumentation;

using TheCodingMonkey.WmiDemo.Common;

namespace TheCodingMonkey.WmiDemo.Source
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeTaskList();
            InitializeBindings();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            // BUG ALERT! YOU MUST DO THIS!!!
            InstrumentationManager.UnregisterType(typeof(Task));
            InstrumentationManager.UnregisterType(typeof(HighPriorityTask));
        }

        private void InitializeBindings()
        {
            _lstBoxTasks.DataSource = Task.TaskList;
            _txtName.DataBindings.Add(new Binding("Text", Task.TaskList, "Name"));
            _txtId.DataBindings.Add(new Binding("Text", Task.TaskList, "TaskId"));
            _dtStart.DataBindings.Add(new Binding("Value", Task.TaskList, "Start"));
            _dtEnd.DataBindings.Add(new Binding("Value", Task.TaskList, "End"));
            _chkCompleted.DataBindings.Add(new Binding("Checked", Task.TaskList, "Completed"));
        }

        private void _lstBoxTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0)
            {
                Task drawTask = ((ListBox)sender).Items[e.Index] as Task;
                Brush taskBrush = Brushes.Black;

                if (drawTask != null)
                {
                    if (drawTask.Completed)
                        taskBrush = Brushes.Green;
                    else if (drawTask is HighPriorityTask)
                        taskBrush = Brushes.Red;
                }

                string text = drawTask != null ? drawTask.ToString() : string.Empty;
                e.Graphics.DrawString(text, e.Font, taskBrush, e.Bounds, StringFormat.GenericDefault);
            }

            e.DrawFocusRectangle();
        }

        private void InitializeTaskList()
        {
            Task.TaskList = new Tasks(Site);
            Task.TaskList.Add(new Task
            {
                Start = new DateTime(2010, 8, 26, 15, 30, 0), 
                End = new DateTime(2010, 8, 26, 16, 20, 0),
                Name = "Drive to Grayslake"
            });

            Task.TaskList.Add(new Task
            {
                Start = new DateTime(2010, 8, 26, 16, 37, 0),
                End = new DateTime(2010, 8, 26, 17, 50, 0),
                Name = "Take Metra to Downtown Chicago"
            });

            Task.TaskList.Add(new Task
            {
                Start = new DateTime(2010, 8, 26, 17, 50, 0),
                End = new DateTime(2010, 8, 26, 18, 0, 0),
                Name = "Walk to Willis Tower"
            });

            Task.TaskList.Add(new Task
            {
                Start = new DateTime(2010, 8, 26, 18, 0, 0),
                End = new DateTime(2010, 8, 26, 18, 30, 0),
                Name = "Eat Pizza"
            });

            Task.TaskList.Add(new Task
            {
                Start = new DateTime(2010, 8, 26, 18, 30, 0),
                End = new DateTime(2010, 8, 26, 20, 0, 0),
                Name = "Application Instrumentation with WMI"
            });

            Task.TaskList.Add(new HighPriorityTask
            {
                Start = new DateTime(2010, 8, 26, 20, 0, 0),
                End = new DateTime(2010, 8, 26, 20, 20, 0),
                Name = "Appease Hecklers"
            });
        }

        private void _cmdRemoveTask_Click(object sender, EventArgs e)
        {
            Task.TaskList.Remove(_lstBoxTasks.SelectedItem as Task);
        }

        private void _cmdAddTask_Click(object sender, EventArgs e)
        {
            Tasks taskList = Task.TaskList as Tasks;
            _lstBoxTasks.SelectedItem = taskList.AddNew();
            _txtName.Focus();
        }

        private void _cmdReminder_Click(object sender, EventArgs e)
        {
            Task remindTask = _lstBoxTasks.SelectedItem as Task;
            remindTask.Remind();
        }
    }
}