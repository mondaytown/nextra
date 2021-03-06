using System;
using System.Web.UI;

namespace NExtra.WebForms.WebControls
{
	/// <summary>
	/// This class represents a submittable / cancelable
	/// user control.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
	public class SubmittableUserControl : UserControl
	{
		public event EventHandler Cancel;
        public event EventHandler Submit;

        public bool Cancelled { get; private set; }
        public bool Submitted { get; private set; }


        public virtual void OnCancel(EventArgs e)
        {
            SetSubmitStatus(false);

	        if (Cancel != null)
	            Cancel(this, e);
	    }

        public virtual void OnSubmit(EventArgs e)
        {
            SetSubmitStatus(true);

			if (Submit != null)
				Submit(this, e);
		}


        private void SetSubmitStatus(bool status)
        {
            Cancelled = !status;
            Submitted = status;
        }
	}
}
