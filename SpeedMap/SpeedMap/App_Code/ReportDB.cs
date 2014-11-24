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
        public const int feedRangeConst = 35; // mile range
        public const int mapRangeConst = 100; // mile range

        public static void insertReport(TrapLocation loc)
        {
            string ins = "INSERT INTO TrapReports" +
                " (User_Id, Latitude, Longitude, Street, City, State, TrapType, ReportTime, ExpireTime )" +
                " VALUES (@User_Id, @Latitude, @Longitude, @Street, @City, @State, @TrapType, @ReportTime, @ExpireTime)";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(ins, con))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("User_Id", loc.User_Id);
                        cmd.Parameters.AddWithValue("Longitude", loc.Longitude);
                        cmd.Parameters.AddWithValue("Latitude", loc.Latitude);
                        cmd.Parameters.AddWithValue("Street", loc.Street);
                        cmd.Parameters.AddWithValue("City", loc.City);
                        cmd.Parameters.AddWithValue("State", loc.State);
                        cmd.Parameters.AddWithValue("TrapType", loc.TrapType);
                        cmd.Parameters.AddWithValue("ReportTime", loc.ReportTime);
                        cmd.Parameters.AddWithValue("ExpireTime", loc.ExpireTime);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        if (ex != null)
                        {
                            string msg = "A database error has occurred.<br /><br />" + ex.Message;
                            if (ex.InnerException != null)
                            {
                                msg += "<br />Message: " + ex.InnerException.Message;
                            }
                            throw new Exception(msg);
                        }
                       
                        
                    }
                    finally
                    {
                        con.Close(); 
                    }
                }
            }
        }

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
            

            loadReportList(lat, lng, feedRangeConst);
            return locationList;
        }

        public static List<DisplayReport> GetLocalMarkerLocations(double lat, double lng)
        {
            

            loadReportList(lat, lng, mapRangeConst);
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

        public static int GetNumNewReports(double lat, double lng, decimal range, int newestTime)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("spGetNumNewLocal", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@userLat", SqlDbType.Decimal, 9, "Latitude"));
                    cmd.Parameters.Add(new SqlParameter("@userLng", SqlDbType.Decimal, 9, "Longitude"));
                    cmd.Parameters.Add(new SqlParameter("@userNewestTime", SqlDbType.Decimal, 10, "ReportTime"));
                    cmd.Parameters.Add(new SqlParameter("@maxRange", SqlDbType.Decimal, 9));
                    SqlParameter returnValue = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Decimal);
                    returnValue.Direction = ParameterDirection.ReturnValue;

                    // assign values to parameters
                    cmd.Parameters["@userLat"].Value = lat;
                    cmd.Parameters["@userLng"].Value = lng;
                    cmd.Parameters["@userNewestTime"].Value = newestTime;
                    cmd.Parameters["@maxRange"].Value = range;

                    // call stored procedure
                    con.Open();
                    cmd.ExecuteNonQuery();
                    int numReports = Convert.ToInt32(returnValue.Value);
                    
                    con.Close();

                    return numReports;
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