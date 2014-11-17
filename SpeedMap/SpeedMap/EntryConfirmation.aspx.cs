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

            // pull username for data entry
            if (Session["loginStatus"] != null)
            {
                // pull the user from cookie
                if (Request.Cookies["userInfo"] != null)
                {
                    string username = Server.HtmlEncode(Request.Cookies["userInfo"]["userName"]);
                    lblUsername.Text = username;
                    hConfirm.InnerHtml = "Thank you " + username + ", for the report";
                }
            }
            else
            {
                // testing
                lblUsername.Text = "UnknownUser"; // hard code error user
            }

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