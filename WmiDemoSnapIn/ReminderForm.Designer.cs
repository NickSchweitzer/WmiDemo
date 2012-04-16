namespace TheCodingMonkey.WmiDemo.SnapIn
{
    partial class ReminderForm
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
            this._imgLate = new System.Windows.Forms.PictureBox();
            this._lblTask = new System.Windows.Forms.Label();
            this._txtTask = new System.Windows.Forms.TextBox();
            this._txtDue = new System.Windows.Forms.TextBox();
            this._lblDue = new System.Windows.Forms.Label();
            this._cmdDismiss = new System.Windows.Forms.Button();
            this._lblMinutes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._imgLate)).BeginInit();
            this.SuspendLayout();
            // 
            // _imgLate
            // 
            this._imgLate.Location = new System.Drawing.Point(13, 13);
            this._imgLate.Name = "_imgLate";
            this._imgLate.Size = new System.Drawing.Size(48, 48);
            this._imgLate.TabIndex = 0;
            this._imgLate.TabStop = false;
            // 
            // _lblTask
            // 
            this._lblTask.AutoSize = true;
            this._lblTask.Location = new System.Drawing.Point(67, 16);
            this._lblTask.Name = "_lblTask";
            this._lblTask.Size = new System.Drawing.Size(34, 13);
            this._lblTask.TabIndex = 1;
            this._lblTask.Text = "Task:";
            // 
            // _txtTask
            // 
            this._txtTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtTask.Location = new System.Drawing.Point(107, 13);
            this._txtTask.Name = "_txtTask";
            this._txtTask.ReadOnly = true;
            this._txtTask.Size = new System.Drawing.Size(223, 20);
            this._txtTask.TabIndex = 2;
            // 
            // _txtDue
            // 
            this._txtDue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtDue.Location = new System.Drawing.Point(107, 41);
            this._txtDue.Name = "_txtDue";
            this._txtDue.ReadOnly = true;
            this._txtDue.Size = new System.Drawing.Size(167, 20);
            this._txtDue.TabIndex = 4;
            // 
            // _lblDue
            // 
            this._lblDue.AutoSize = true;
            this._lblDue.Location = new System.Drawing.Point(67, 44);
            this._lblDue.Name = "_lblDue";
            this._lblDue.Size = new System.Drawing.Size(30, 13);
            this._lblDue.TabIndex = 3;
            this._lblDue.Text = "Due:";
            // 
            // _cmdDismiss
            // 
            this._cmdDismiss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cmdDismiss.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._cmdDismiss.Location = new System.Drawing.Point(251, 73);
            this._cmdDismiss.Name = "_cmdDismiss";
            this._cmdDismiss.Size = new System.Drawing.Size(79, 31);
            this._cmdDismiss.TabIndex = 5;
            this._cmdDismiss.Text = "Dismiss";
            this._cmdDismiss.UseVisualStyleBackColor = true;
            // 
            // _lblMinutes
            // 
            this._lblMinutes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblMinutes.AutoSize = true;
            this._lblMinutes.Location = new System.Drawing.Point(280, 44);
            this._lblMinutes.Name = "_lblMinutes";
            this._lblMinutes.Size = new System.Drawing.Size(50, 13);
            this._lblMinutes.TabIndex = 6;
            this._lblMinutes.Text = "(Minutes)";
            // 
            // ReminderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 110);
            this.Controls.Add(this._lblMinutes);
            this.Controls.Add(this._cmdDismiss);
            this.Controls.Add(this._txtDue);
            this.Controls.Add(this._lblDue);
            this.Controls.Add(this._txtTask);
            this.Controls.Add(this._lblTask);
            this.Controls.Add(this._imgLate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReminderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Task Reminder";
            ((System.ComponentModel.ISupportInitialize)(this._imgLate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _imgLate;
        private System.Windows.Forms.Label _lblTask;
        private System.Windows.Forms.TextBox _txtTask;
        private System.Windows.Forms.TextBox _txtDue;
        private System.Windows.Forms.Label _lblDue;
        private System.Windows.Forms.Button _cmdDismiss;
        private System.Windows.Forms.Label _lblMinutes;
    }
}