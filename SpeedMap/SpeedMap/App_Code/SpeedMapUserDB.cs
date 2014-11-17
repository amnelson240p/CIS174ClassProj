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
    public class SpeedMapUserDB
    {
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertUser(SpeedMapUser user)
        {
            string ins = "INSERT INTO UserInfo (Username, Password) VALUES (@Username, @Password)";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(ins, con))
                {
                    cmd.Parameters.AddWithValue("Username", user.Username);
                    cmd.Parameters.AddWithValue("Password", user.Password);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close(); // may not be needed
                }
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static int getUserID(string username, string password)
        {
            int userId = -1;
            string sel = "SELECT User_Id" +
                " FROM UserInfo" +
                " WHERE Username=@Username AND Password=@Password";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sel, con))
                {
                    cmd.Parameters.AddWithValue("Username", username);
                    cmd.Parameters.AddWithValue("Password", password);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                       
                     userId = Convert.ToInt32(dr["User_Id"]);
                        

                    }
                    else
                    {
                        // failed to find match userId remains -1
                       
                    }
                    con.Close(); // may not be needed
                }
            }
            
            return userId;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static int verifyLogin(string username, string password)
        {
            // note input validation should have been performed prior to using this method
            int userId = -1;

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("spLogin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar,15, "Username"));
                    cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 30, "Password"));
                    cmd.Parameters.Add(new SqlParameter("@tmpUserID", SqlDbType.Int,0, ParameterDirection.Output, false,10,0, "User_Id", DataRowVersion.Default, null));
                    cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;

                    // assign values to parameters
                    cmd.Parameters["@username"].Value = username;
                    cmd.Parameters["@password"].Value = password;

                    // call stored procedure
                    con.Open();
                    cmd.ExecuteNonQuery();
                    userId = Convert.ToInt32(cmd.Parameters["@tmpUserID"].Value);
                    con.Close();
                }
            }

            return userId;
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings
            ["SpeedTrapConnectionString"].ConnectionString;
        }
    }


}