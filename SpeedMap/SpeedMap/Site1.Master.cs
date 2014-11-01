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

        protected void Page_Load(object sender, EventArgs e)
        {
            // which nav is active

            int nav = -1;
            if ((Session["Navigation"] != null))
            {
                nav = (int)(Session["Navigation"]);
            }
            switch (nav)
            {
                case 0:
                    Console.WriteLine("Home nav");
                    lbtnHome.Attributes.Add("class", "isActive");
                    break;
                case 1:
                    Console.WriteLine("Entry nav");
                    lbtnEntry.Attributes.Add("class", "isActive");
                    break;
                case 2:
                    Console.WriteLine("Map nav");
                    lbtnMap.Attributes.Add("class", "isActive");
                    break;
                case 3:
                    Console.WriteLine("Feed nav");
                    lbtnFeed.Attributes.Add("class", "isActive");
                    break;
                default:
                    Console.WriteLine("Home nav");
                    lbtnHome.Attributes.Add("class", "isActive");
                    break;

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
            //Response.Redirect("GeoCodeTest.aspx");
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

    }
}