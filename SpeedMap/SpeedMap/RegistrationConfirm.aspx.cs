using SpeedMap.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMap
{
    public partial class RegistrationConfirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("Registration");
            SpeedMapUser newUser = (SpeedMapUser)Session["NewUser"];

            lblNewUser.Text = newUser.Username.ToString();
        }
    }
}