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
            // store username
            trapLoc.Username = "testuser"; // hardcoded for testing

            //store traplocation object in session for testing
            Session["ReportLocation"] = trapLoc;

            
            
            // database entry here

            // if everything is ok and stores in the database correctly
            // redirect to confirmation
            Response.Redirect("EntryConfirmation.aspx");

            // If there were errors redirect to error page?
        }
    }
}