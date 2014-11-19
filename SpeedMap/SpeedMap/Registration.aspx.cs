using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpeedMap.App_Code;

namespace SpeedMap
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void btnValidation_Click(object sender, EventArgs e)
        {
            //bool validate = SpeedMapUserDB.verifyUsername("Bmuir44");
            //lblUsernameValidation.Text = validate.ToString();
        }
    }
}