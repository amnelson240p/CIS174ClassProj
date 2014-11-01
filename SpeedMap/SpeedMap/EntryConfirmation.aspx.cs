using SpeedMap.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMap
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TrapLocation storedLoc;
            storedLoc = (TrapLocation)Session["ReportLocation"];

            // update labels with object properties
            lblUsername.Text = storedLoc.Username.ToString();
            lblLongitude.Text = storedLoc.trapLongitude.ToString();
            lblLatitude.Text = storedLoc.trapLatitude.ToString();
            lblReportTime.Text = storedLoc.reportTime.ToString();
            lblExpireTime.Text = storedLoc.ExpireTime.ToString();

            // test
        }
    }
}