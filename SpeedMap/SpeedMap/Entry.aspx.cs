// Entry.aspx.cs
// 11/2/2014 - Aaron Nelson
// This page allows users to toggle a marker icon to select trap type. They can drag the marker on the map to the trap location and submit (Report Trap). 
// Prior to submission, street, city, and state are generated based of marker location (latitude and longitude). 
// These data fields are passed to the server to be stored in the database.
// login information is used to identify submission.

using SpeedMap.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMap
{
    public partial class Entry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Entry Map", "lookup_location()", true);

            // pull username for data entry
            if (Session["loginStatus"] != null)
            {
                // pull the user from cookie
                if (Request.Cookies["userInfo"] != null)
                {
                    hfUsername.Value = Server.HtmlEncode(Request.Cookies["userInfo"]["userName"]);
                }
            }
            else 
            {
                // testing
                hfUsername.Value = "UnknownUser"; // hard code error user

                // Not logged in or no session(timeout?). Redirect to Index.aspx
                Session["Navigation"] = 0;  // reset navigation flags for Index.aspx
                Response.Redirect("Index.aspx");

            }
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
                     
            
            
            if (Session["ReportLocation"] != null)
            {
                // database entry here

                // if everything is ok and stores in the database correctly
                
                // ok we are good to go. redirect to confirmation
                Response.Redirect("EntryConfirmation.aspx");
            }
            

            // If there were errors redirect to error page?
        }

        
        
        [WebMethod]
        public static void storeData(string lat, string lng, string street, string city, string state, string type, string username)
        {
            // Traplocation fields
            // Username
            // longitude
            // latitude
            // Street
            // City
            // State
            // Trap type
            // Trap time

            TrapLocation trapLoc = new TrapLocation();
            
            
            // fill in other fields
            trapLoc.Username = username;
            trapLoc.trapLatitude = Convert.ToSingle(lat);
            trapLoc.trapLongitude = Convert.ToSingle(lng);
            trapLoc.TrapStreet = street;
            trapLoc.TrapCity = city;
            trapLoc.TrapState = state;
            trapLoc.TrapType = Convert.ToChar(type);
            // immediately following storing type, record server time and store in object
            trapLoc.recordReportTime();

            

            //store traplocation object in session for testing
            //Session["ReportLocation"] = trapLoc;
            HttpContext.Current.Session.Add("ReportLocation", trapLoc); // needed syntax for the static method (outside webform)

            
            
        }
    }
}