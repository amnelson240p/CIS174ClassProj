using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedMap.App_Code
{
    [DataObject(true)]
    public static class ReportDB
    {
        private static List<DisplayReport> locationList;

        public static List<DisplayReport> GetReports()
        {
            loadLocationList();
            return locationList;
        }

        private static void loadLocationList()
        {
            locationList = new List<DisplayReport>();

            SqlConnection con = new SqlConnection(GetConnectionString());
            string sel = "SELECT Latitude, Longitude, Street, City, TrapType, ReportTime" +
                " FROM TrapReports";
            SqlCommand cmd = new SqlCommand(sel, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DisplayReport location;
            // loop through data reader and load row data into new user objects and add to list.
            while (dr.Read())
            {
                location = new DisplayReport();
               
                location.Latitude = Convert.ToDouble(dr["Latitude"]);
                location.Longitude = Convert.ToDouble(dr["Longitude"]);
                location.Street = dr["Street"].ToString();
                location.City = dr["City"].ToString();
                location.TrapType = dr["TrapType"].ToString();
                location.ReportTime = Convert.ToInt32(dr["ReportTime"]);

                locationList.Add(location);
            }
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings
            ["SpeedTrapConnectionString"].ConnectionString;
        }
    }
}