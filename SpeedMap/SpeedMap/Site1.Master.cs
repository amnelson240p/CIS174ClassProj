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
        private readonly string[] Nav_Names = {"Home", "Entry", "Map", "Feed"};
        private string activeNav; // initialzed to home navigation

        protected void Page_Load(object sender, EventArgs e)
        {
            // which nav is active
            
        }

        protected void lbtnHome_Click(object sender, EventArgs e)
        {
            // remove old active status
            removeActiveStatus();

            // set home nav to active
            activeNav = Nav_Names[0];
            lbtnHome.Attributes.Add("class", "isActive");
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
            lbtnEntry.Attributes.Add("class", "isActive");
        }

        protected void lbtnMap_Click(object sender, EventArgs e)
        {
            // remove old active status
            removeActiveStatus();

            // set Map nav to active
            activeNav = Nav_Names[2]; // "Map"
            lbtnMap.Attributes.Add("class", "isActive");
        }

        protected void lbtnFeed_Click(object sender, EventArgs e)
        {
            // remove old active status
            removeActiveStatus();

            // set Feed nav to active
            activeNav = Nav_Names[2]; // "Feed"
            lbtnFeed.Attributes.Add("class", "isActive");
        }
    }
}