using SpeedMap.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMap
{
    public partial class Map : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ibtnRefresh.Attributes.Add("OnMouseOver", "src='images/Refresh3.png'");
            ibtnRefresh.Attributes.Add("OnMouseOut", "src='images/Refresh2.png'");

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
        public static string GetLocalData(double lat, double lng)
        {
            // calling Feed method to get local trap reports
            List<DisplayReport> reportList = ReportDB.GetLocalMarkerLocations(lat, lng);
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(reportList);

            return json;
        }

        [WebMethod]
        public static string GetRecentReports(double lat, double lng, int now)
        {
            // call method to get number of reports within defined range 
            int numNew = ReportDB.GetNumNewReports(lat, lng, ReportDB.mapRangeConst, now);
            //int numNew = 5;
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(numNew);
            return json;
        }

        protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            // refresh
            Response.Redirect(Request.RawUrl);
        }
    }
}