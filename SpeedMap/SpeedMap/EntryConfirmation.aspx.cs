// Aaron Nelson
// EntryConfirmation.aspx.cs
// EntryConfirmation page can only be
// accessed through successful completion 
// of a trap report being sent to and stored
// in the database.
// Testing -- html elements for trap report fields
// are displayed and filled in using the trap report object
// that was successfully stored in session.


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
            
            
            // stop navigation to this page without a report
            if (Session["loginStatus"] != null &&
                (Session["ReportLocation"] != null))
            {
                TrapLocation storedLoc;
                storedLoc = (TrapLocation)Session["ReportLocation"];
            
            
                // pull the username from cookie
                if (Request.Cookies["userInfo"] != null)
                {

                    string username = Server.HtmlEncode(Request.Cookies["userInfo"]["userName"]);
                    lblUsername.Text = username;
                    hConfirm.InnerHtml = "Thank you " + username + ", for the report";

                    // update labels with object properties
                    //lblUsername.Text = storedLoc.Username.ToString();
                    lblLongitude.Text = storedLoc.Longitude.ToString();
                    lblLatitude.Text = storedLoc.Latitude.ToString();
                    lblReportTime.Text = storedLoc.ReportTime.ToString();
                    lblExpireTime.Text = storedLoc.ExpireTime.ToString();
                    lblStreet.Text = storedLoc.Street.ToString();
                    lblCity.Text = storedLoc.City.ToString();
                    lblState.Text = storedLoc.State.ToString();
                    lblTrapType.Text = storedLoc.TrapType.ToString();
                }
            }
            else
            {
                // Redirect to Index.aspx
                Session["Navigation"] = 0;  // reset navigation flags for Index.aspx
                Response.Redirect("Index.aspx");
            }

            

            

        }

        protected void btnMaps_Click(object sender, EventArgs e)
        {

            if ((Session["Navigation"] != null))
            {

                Session["Navigation"] = 2;
                Response.Redirect("Map.aspx");
            }
        }
    }
}