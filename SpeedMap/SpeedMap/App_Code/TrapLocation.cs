using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedMap.App_Code
{

    public class TrapLocation
    {
        private DateTime startTime;
        private long reportTime;
        private long expireTime; // to be set 5 days after initial report
        private string trapType; // flag for mobile or fixed (M or F)
        private string trapCity;
        private string trapStreet;
        private string trapState;
        private int userId; // from database
        private double trapLatitude;
        private double trapLongitude;


       
        public TrapLocation()
        {
        }
        public TrapLocation(string json)
        {

        }

        // properties
        
        public double Latitude
        {
            get { return trapLatitude; }
            set { trapLatitude = value; }
        }
        public double Longitude
        {
            get { return trapLongitude; }
            set { trapLongitude = value; }
        }
        public string Street
        {
            get { return trapStreet; }
            set { trapStreet = value; }
        }
        public string City
        {
            get { return trapCity; }
            set { trapCity = value; }
        }
        
        public string State
        {
            get { return trapState; }
            set { trapState = value; }
        }
        public string TrapType
        {
            get { return trapType; }
            set { trapType = value; }
        }
        public int User_Id
        {
            get { return userId; }
            set { userId = value; }
        }
        public long ReportTime
        {
            get { return reportTime; }
            set { reportTime = value; }
        }
        public long ExpireTime
        {
            get { return expireTime; }
            set { expireTime = value; }
        }

        // special method to handle storing the report time
        public void recordReportTime()
        {
            // start measuring time from Jan 1, 2014
            startTime = new DateTime(2014, 1, 1);

            // get server time
            DateTime currentDate = DateTime.Now;

            // use elapsed time in seconds from start to current
            //reportTime = (currentDate - startTime).TotalSeconds;
            reportTime = Convert.ToInt64((currentDate - startTime).TotalSeconds);

            if (TrapType.CompareTo("M") == 0)
            {
                // 5 days = 432000 seconds
                // establish expireTime 5 days from reportTime
                expireTime = reportTime + 432000;
            }
            else
            {
                // fixed trap
                // one year in seconds = 31,536,000
                expireTime = reportTime + (31536000 * 5); // 5 years
            }
        }
        public bool storeUser()
        {
            if (HttpContext.Current.Session["userID"] != null)
            {
                userId = Convert.ToInt16(HttpContext.Current.Session["userID"]);
                return true;
            }
            else
                return false;
        }
    }
}