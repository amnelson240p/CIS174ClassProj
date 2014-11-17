using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using SpeedMap.App_Code;


namespace SpeedMap
{
    public partial class WebForm1 : System.Web.UI.Page
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

        [WebMethod]
        public static string GetData()
        {
            List<DisplayReport> reportList = ReportDB.GetReports();
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(reportList);

            return json;
        }
    }
}