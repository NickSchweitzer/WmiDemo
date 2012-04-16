namespace TheCodingMonkey.WmiDemo.Source
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._lstBoxTasks = new System.Windows.Forms.ListBox();
            this._lblTaskList = new System.Windows.Forms.Label();
            this._lblName = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._lblId = new System.Windows.Forms.Label();
            this._lblStart = new System.Windows.Forms.Label();
            this._txtId = new System.Windows.Forms.Label();
            this._dtStart = new System.Windows.Forms.DateTimePicker();
            this._dtEnd = new System.Windows.Forms.DateTimePicker();
            this._lblTo = new System.Windows.Forms.Label();
            this._lblReminders = new System.Windows.Forms.Label();
            this._chkCompleted = new System.Windows.Forms.CheckBox();
            this._cmdReminder = new System.Windows.Forms.Button();
            this._cmdAddTask = new System.Windows.Forms.Button();
            this._cmdRemoveTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lstBoxTasks
            // 
            this._lstBoxTasks.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._lstBoxTasks.FormattingEnabled = true;
            this._lstBoxTasks.Location = new System.Drawing.Point(15, 25);
            this._lstBoxTasks.Name = "_lstBoxTasks";
            this._lstBoxTasks.Size = new System.Drawing.Size(433, 199);
            this._lstBoxTasks.TabIndex = 1;
            this._lstBoxTasks.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this._lstBoxTasks_DrawItem);
            // 
            // _lblTaskList
            // 
            this._lblTaskList.AutoSize = true;
            this._lblTaskList.Location = new System.Drawing.Point(12, 9);
            this._lblTaskList.Name = "_lblTaskList";
            this._lblTaskList.Size = new System.Drawing.Size(53, 13);
            this._lblTaskList.TabIndex = 0;
            this._lblTaskList.Text = "Task List:";
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Location = new System.Drawing.Point(18, 242);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(35, 13);
            this._lblName.TabIndex = 2;
            this._lblName.Text = "Name";
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(59, 239);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(180, 20);
            this._txtName.TabIndex = 3;
            // 
            // _lblId
            // 
            this._lblId.AutoSize = true;
            this._lblId.Location = new System.Drawing.Point(18, 268);
            this._lblId.Name = "_lblId";
            this._lblId.Size = new System.Drawing.Size(18, 13);
            this._lblId.TabIndex = 4;
            this._lblId.Text = "ID";
            // 
            // _lblStart
            // 
            this._lblStart.AutoSize = true;
            this._lblStart.Location = new System.Drawing.Point(18, 294);
            this._lblStart.Name = "_lblStart";
            this._lblStart.Size = new System.Drawing.Size(29, 13);
            this._lblStart.TabIndex = 6;
            this._lblStart.Text = "Start";
            // 
            // _txtId
            // 
            this._txtId.AutoSize = true;
            this._txtId.Location = new System.Drawing.Point(59, 268);
            this._txtId.Name = "_txtId";
            this._txtId.Size = new System.Drawing.Size(13, 13);
            this._txtId.TabIndex = 5;
            this._txtId.Text = "0";
            // 
            // _dtStart
            // 
            this._dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this._dtStart.Location = new System.Drawing.Point(59, 290);
            this._dtStart.Name = "_dtStart";
            this._dtStart.Size = new System.Drawing.Size(180, 20);
            this._dtStart.TabIndex = 7;
            // 
            // _dtEnd
            // 
            this._dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this._dtEnd.Location = new System.Drawing.Point(268, 290);
            this._dtEnd.Name = "_dtEnd";
            this._dtEnd.Size = new System.Drawing.Size(180, 20);
            this._dtEnd.TabIndex = 11;
            // 
            // _lblTo
            // 
            this._lblTo.AutoSize = true;
            this._lblTo.Location = new System.Drawing.Point(246, 294);
            this._lblTo.Name = "_lblTo";
            this._lblTo.Size = new System.Drawing.Size(16, 13);
            this._lblTo.TabIndex = 10;
            this._lblTo.Text = "to";
            // 
            // _lblReminders
            // 
            this._lblReminders.AutoSize = true;
            this._lblReminders.Location = new System.Drawing.Point(265, 242);
            this._lblReminders.Name = "_lblReminders";
            this._lblReminders.Size = new System.Drawing.Size(66, 13);
            this._lblReminders.TabIndex = 8;
            this._lblReminders.Text = "0 Reminders";
            // 
            // _chkCompleted
            // 
            this._chkCompleted.AutoSize = true;
            this._chkCompleted.Location = new System.Drawing.Point(268, 267);
            this._chkCompleted.Name = "_chkCompleted";
            this._chkCompleted.Size = new System.Drawing.Size(76, 17);
            this._chkCompleted.TabIndex = 9;
            this._chkCompleted.Text = "Completed";
            this._chkCompleted.UseVisualStyleBackColor = true;
            // 
            // _cmdReminder
            // 
            this._cmdReminder.Location = new System.Drawing.Point(15, 338);
            this._cmdReminder.Name = "_cmdReminder";
            this._cmdReminder.Size = new System.Drawing.Size(82, 30);
            this._cmdReminder.TabIndex = 12;
            this._cmdReminder.Text = "Reminder!";
            this._cmdReminder.UseVisualStyleBackColor = true;
            this._cmdReminder.Click += new System.EventHandler(this._cmdReminder_Click);
            // 
            // _cmdAddTask
            // 
            this._cmdAddTask.Location = new System.Drawing.Point(190, 338);
            this._cmdAddTask.Name = "_cmdAddTask";
            this._cmdAddTask.Size = new System.Drawing.Size(82, 30);
            this._cmdAddTask.TabIndex = 13;
            this._cmdAddTask.Text = "Add Task";
            this._cmdAddTask.UseVisualStyleBackColor = true;
            this._cmdAddTask.Click += new System.EventHandler(this._cmdAddTask_Click);
            // 
            // _cmdRemoveTask
            // 
            this._cmdRemoveTask.Location = new System.Drawing.Point(365, 338);
            this._cmdRemoveTask.Name = "_cmdRemoveTask";
            this._cmdRemoveTask.Size = new System.Drawing.Size(82, 30);
            this._cmdRemoveTask.TabIndex = 14;
            this._cmdRemoveTask.Text = "Remove Task";
            this._cmdRemoveTask.UseVisualStyleBackColor = true;
            this._cmdRemoveTask.Click += new System.EventHandler(this._cmdRemoveTask_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 380);
            this.Controls.Add(this._cmdRemoveTask);
            this.Controls.Add(this._cmdAddTask);
            this.Controls.Add(this._cmdReminder);
            this.Controls.Add(this._chkCompleted);
            this.Controls.Add(this._lblReminders);
            this.Controls.Add(this._lblTo);
            this.Controls.Add(this._dtEnd);
            this.Controls.Add(this._dtStart);
            this.Controls.Add(this._txtId);
            this.Controls.Add(this._lblStart);
            this.Controls.Add(this._lblId);
            this.Controls.Add(this._txtName);
            this.Controls.Add(this._lblName);
            this.Controls.Add(this._lblTaskList);
            this.Controls.Add(this._lstBoxTasks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Task Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _lstBoxTasks;
        private System.Windows.Forms.Label _lblTaskList;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.Label _lblId;
        private System.Windows.Forms.Label _lblStart;
        private System.Windows.Forms.Label _txtId;
        private System.Windows.Forms.DateTimePicker _dtStart;
        private System.Windows.Forms.DateTimePicker _dtEnd;
        private System.Windows.Forms.Label _lblTo;
        private System.Windows.Forms.Label _lblReminders;
        private System.Windows.Forms.CheckBox _chkCompleted;
        private System.Windows.Forms.Button _cmdReminder;
        private System.Windows.Forms.Button _cmdAddTask;
        private System.Windows.Forms.Button _cmdRemoveTask;
    }
}

