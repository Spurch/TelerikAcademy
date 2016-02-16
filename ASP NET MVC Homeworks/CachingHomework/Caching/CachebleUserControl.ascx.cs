namespace Caching
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class CachebleUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CacheControl.Text = "Last cache at " + DateTime.Now.TimeOfDay.ToString();
        }
    }
}