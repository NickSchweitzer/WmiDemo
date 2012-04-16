using System;
using System.ComponentModel;
using System.Configuration.Install;

namespace TheCodingMonkey.WmiDemo.Source
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
