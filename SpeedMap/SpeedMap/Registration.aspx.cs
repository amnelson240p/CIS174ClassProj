using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpeedMap.App_Code;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace SpeedMap
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        [WebMethod]
        public static string VerifyNewUser(string username)
        {
            bool isUnique = false;
            isUnique = SpeedMapUserDB.verifyUniqueUsername(username);

            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(isUnique);
            return json;
        }

        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            // do stuff
            SpeedMapUser newUser = new SpeedMapUser();
            newUser.Username = txtUsername.Text;
            newUser.Password = txtPassword.Text;

            

            try
            {
                SpeedMapUserDB.InsertUser(newUser);
            }
            catch (Exception ex)
            {
                lblDatabaseError.Text = ex.Message;
            }
            finally
            {
                Session["NewUser"] = newUser;
                Response.Redirect("RegistrationConfirm.aspx");
            }

            
        }
    }
}