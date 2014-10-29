using SpeedMap.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMap
{
    public partial class Entry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Entry Map", "lookup_location()", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // stuff to do when user submits a speed trap location
            // create a location object
            TrapLocation trapLoc = new TrapLocation();
            // immediately record server time and store in object
            trapLoc.recordReportTime();
            // for now, use the textboxes to store longitude and latitude
            trapLoc.trapLatitude = Convert.ToSingle(txtLatitude.Text);
            trapLoc.trapLongitude = Convert.ToSingle(txtLongitude.Text);

            // testing class for database entry
            // eventually will remove this code
            lblReportTime.Text = trapLoc.reportTime.ToString();
            lblExpireTime.Text = trapLoc.ExpireTime.ToString();
        }
    }
}