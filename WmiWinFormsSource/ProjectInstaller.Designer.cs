namespace TheCodingMonkey.WmiDemo.Source
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.oldMgmtInstaller = new System.Management.Instrumentation.DefaultManagementProjectInstaller();
            this.newMgmInstaller = new System.Management.Instrumentation.DefaultManagementInstaller();
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.oldMgmtInstaller,
            this.newMgmInstaller
            });
        }

        #endregion

        private System.Management.Instrumentation.DefaultManagementProjectInstaller oldMgmtInstaller;
        private System.Management.Instrumentation.DefaultManagementInstaller newMgmInstaller;
    }
}