#region Using Directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

using Microsoft.ManagementConsole;

#endregion

namespace TheCodingMonkey.WmiDemo.SnapIn.Views
{
    public class DetailsPropertyPage<T> : PropertyPage
        where T : PropertyPageControl
    {
        private T PropertyControl;

        #region Construction

        public DetailsPropertyPage(string title, T control)
        {
            Title = title;
            PropertyControl = control;
            Control = control;
            Control.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        #endregion

        #region Public Properties

        public T DetailsControl
        {
            get { return Control as T; }
        }

        #endregion

        #region Override Methods

        protected override bool OnApply()
        {
            return PropertyControl.OnApply();
        }

        protected override bool OnOK()
        {
            return PropertyControl.OnOK();
        }

        protected override bool OnKillActive()
        {
            return true;
        }

        protected override bool QueryCancel()
        {
            return true;
        }

        #endregion
    }
}