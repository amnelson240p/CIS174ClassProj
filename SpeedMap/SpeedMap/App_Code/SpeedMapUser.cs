using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedMap.App_Code
{
    public class SpeedMapUser
    {
        private string username;
        private string password;
        private int userID;

        public SpeedMapUser()
        {
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int User_Id
        {
            get { return userID; }
            set { userID = value; }
        }
    }
}