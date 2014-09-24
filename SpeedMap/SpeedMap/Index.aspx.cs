using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMap
{
    public partial class Index : System.Web.UI.Page
    {
        // assume we are going to handle login stuff for the whole application through session
        // but have no idea how that is handled just yet so testing the flag

        private bool isloggedIn = true; // test flag

        protected void Page_Load(object sender, EventArgs e)
        {
            if (isloggedIn)
            {
                // change the login bar to greet user or some other simple message
            }
           
        }
    }
}