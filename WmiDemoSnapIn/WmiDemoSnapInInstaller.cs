#region  Using Directives

using System;
using System.ComponentModel;

using Microsoft.ManagementConsole;

#endregion

namespace TheCodingMonkey.WmiDemo.SnapIn
{
    [RunInstaller(true)]
    public class WmiDemoSnapInInstaller : SnapInInstaller
    {
    }
}