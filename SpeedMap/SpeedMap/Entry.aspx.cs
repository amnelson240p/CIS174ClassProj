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

            // verify session and login status
            if (Session["loginStatus"] != null)
            {
                // session but not logged in
                if ((bool)Session["loginStatus"] == false)
                {
                    // Not logged in or no session(timeout?). Redirect to Index.aspx
                    Session["Navigation"] = 0;  // reset navigation flags for Index.aspx
                    Response.Redirect("Index.aspx");
                }

            }
            // no session stored
            else
            {
                // Redirect to Index.aspx
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
        public static void storeData(TrapLocation trapLoc)
        {
            // Traplocation fields
            // Latitude
            // Longitude
            // Street
            // City
            // State
            // Trap type
            // User_Id
            // Trap time - ReportTime
            // ExpireTime

            
        
            // immediately following storing type, record server time and store in object
            trapLoc.recordReportTime();

            // store User_Id from session in location object
            if (trapLoc.storeUser())
            {
                // userId exists. safe  to store TrapLocation object in session
                HttpContext.Current.Session.Add("ReportLocation", trapLoc); // needed syntax for the static method (outside webform)

                // safe to attempt to store in database

            }
        }
    }
}