// Site1.Master.cs
// Updated 11/2/2014 for basic login navigation - Aaron Nelson
// Structure - Aaron Nelson

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMap
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        private readonly string[] Nav_Names = { "Home", "Entry", "Map", "Feed" };
        private string activeNav; // initialzed to home navigation
        private bool loginstatus; // flag for holding login status

        protected void Page_Load(object sender, EventArgs e)
        {
            removeActiveStatus(); // clear navigation attributes for css

            if (!IsPostBack)
            {
                // attempt to pull username from cookies
                if (Request.Cookies["userInfo"] != null)
                {
                    txtUsername.Text = Request.Cookies["userInfo"]["userName"];
                }
            }

            // which nav is active is stored in session
            int nav = -1;
            if ((Session["Navigation"] != null))
            {
                nav = (int)(Session["Navigation"]);
            }
            else
            {
                nav = 0;
            }
            switch (nav)
            {
                case 0:
                    lbtnHome.Attributes.Add("class", "isActive");
                    break;
                case 1:
                    lbtnEntry.Attributes.Add("class", "isActive");
                    break;
                case 2:
                    lbtnMap.Attributes.Add("class", "isActive");
                    break;
                case 3:
                    lbtnFeed.Attributes.Add("class", "isActive");
                    break;
                default:
                    lbtnHome.Attributes.Add("class", "isActive");
                    break;

            }

            // do stuff with login status
            // first pull status from session if available
            if (Session["loginStatus"] != null)
            {
                loginstatus = (bool)(Session["loginStatus"]);
            }
            else
            {
                loginstatus = false;
            }
            // update visible elements based on status
            if (!loginstatus)
            {
                loggedin.Visible = false;
            }
            else
            {
                // we are logged in
                loggedout.Visible = false;
                loggedin.Visible = true;
                // pull username from cookie if available
                if (Request.Cookies["userInfo"] != null)
                {
                    lblUser.Text = Request.Cookies["userInfo"]["userName"];
                }
                else
                {
                    // no cookie with user info
                    lblUser.Text = "noCookie";
                }
            }

        }

        protected void lbtnHome_Click(object sender, EventArgs e)
        {
            // remove old active status
            removeActiveStatus();

            // set home nav to active
            activeNav = Nav_Names[0];
            Session["Navigation"] = 0;

            Response.Redirect("Index.aspx");
        }

        // doesn't need to be run by outside classes or child classes directly
        private void removeActiveStatus()
        {
            // removing old status by removing html attribute "class"
            lbtnHome.Attributes.Remove("class");
            lbtnEntry.Attributes.Remove("class");
            lbtnMap.Attributes.Remove("class");
            lbtnFeed.Attributes.Remove("class");
        }

        protected void lbtnEntry_Click(object sender, EventArgs e)
        {
            // remove old active status
            removeActiveStatus();

            // set Entry nav to active
            activeNav = Nav_Names[1]; // "Entry"
            Session["Navigation"] = 1;


            Response.Redirect("Entry.aspx");
        }

        protected void lbtnMap_Click(object sender, EventArgs e)
        {
            // remove old active status
            removeActiveStatus();

            // set Map nav to active
            activeNav = Nav_Names[2]; // "Map"
            Session["Navigation"] = 2;

            Response.Redirect("Map.aspx");
        }

        protected void lbtnFeed_Click(object sender, EventArgs e)
        {
            // remove old active status
            removeActiveStatus();

            // set Feed nav to active
            activeNav = Nav_Names[3]; // "Feed"
            Session["Navigation"] = 3;

            Response.Redirect("Feed.aspx");

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            bool isValid = true; // hard code test for now need to fix <<<<<<<<<
            // validation? ****************** FIX *******************
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            int userId; // userId from database

            // logic to verify correct username + password
            // needs database access ******** NEED CODE HERE ***************
            // does username and password match database?
            if (!isValid)
            {

                // verify fail
                loginstatus = false;
                Session["loginStatus"] = loginstatus;
                // code to message incorrect password combo (or page) ******* Fix ******


            }
            else // success
            {
                userId = 4; // hard coded test >>>>> REMOVE THIS LINE WHEN DATABASE IS WORKING <<<<<
                // verify success



                Response.Cookies["userInfo"]["userName"] = user;

                if (chkRemember.Checked)
                {
                    // persistent cookie
                    Response.Cookies["userInfo"].Expires = DateTime.Now.AddYears(1);
                }
                else
                {
                    Response.Cookies["userInfo"].Expires = DateTime.Now.AddHours(1);
                }


                // assign name to loggedin control
                lblUser.Text = user;

                // clear textboxes - may not be needed
                txtUsername.Text = "";
                txtPassword.Text = "";

                loggedout.Visible = false;
                loggedin.Visible = true;
                loginstatus = true; // change status flag
                // store activated login status in session state
                Session["loginStatus"] = loginstatus;
                // store userId
                Session["userId"] = userId;
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            // attempt to pull username from cookies
            if (Request.Cookies["userInfo"] != null)
            {
                txtUsername.Text = Request.Cookies["userInfo"]["userName"];
            }
            // clear username from label in loggedin control
            lblUser.Text = "";
            // toggle visibility of login controls
            loggedout.Visible = true;
            loggedin.Visible = false;
            loginstatus = false;
            Session["loginStatus"] = loginstatus;
            // clear userID from session
            Session.Remove("userId");

            // Redirect to Index.aspx
            Session["Navigation"] = 0;  // reset navigation flags for Index.aspx
            Response.Redirect("Index.aspx");

        }

    }
}