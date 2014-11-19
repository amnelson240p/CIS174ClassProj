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

        public static List<DisplayReport> GetLocalFeedReports(double lat, double lng)
        {
            decimal range = 35; // feed range will be shorter than map 

            loadReportList(lat, lng, range);
            return locationList;
        }

        public static List<DisplayReport> GetLocalMarkerLocations(double lat, double lng)
        {
            decimal range = 150; // Marker range larger for Map page 

            loadReportList(lat, lng, range);
            return locationList;
        }

        private static void loadReportList(double lat, double lng, decimal range)
        {
            locationList = new List<DisplayReport>(); // clean list

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("spGetDisplayTraps", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@userLat", SqlDbType.Decimal, 9, "Latitude"));
                    cmd.Parameters.Add(new SqlParameter("@userLng", SqlDbType.Decimal, 9, "Longitude"));
                    cmd.Parameters.Add(new SqlParameter("@maxRange", SqlDbType.Decimal, 9));

                    // assign values to parameters
                    cmd.Parameters["@userLat"].Value = lat;
                    cmd.Parameters["@userLng"].Value = lng;
                    cmd.Parameters["@maxRange"].Value = range;

                    // call stored procedure
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
                    con.Close();
                }
            }
        }


        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings
            ["SpeedTrapConnectionString"].ConnectionString;
        }
    }
}