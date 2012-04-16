using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TheCodingMonkey.WmiDemo.Source
{
    static class Program
    {
        /// <summary>The main entry point for the application.</summary>
        //[STAThread]
        [MTAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}