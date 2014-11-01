using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedMap.App_Code
{
    public class TrapLocation
    {
        private DateTime startTime;
        private long expireTime; // to be set 5 days after initial report
        private char trapType; // flag for mobile or fixed (M or F)
        private string trapCity;
        private string trapStreet;
        private string trapState;
        private string username; // username who reported trap location

        public TrapLocation()
        {
            // start measuring time from Jan 1, 2014
            startTime = new DateTime(2014, 1, 1);
        }

        // properties
        public long reportTime { get; set; }
        public double trapLatitude { get; set; }
        public double trapLongitude { get; set; }
        public long ExpireTime
        {
            get { return expireTime; }
        }
        public char TrapType
        {
            get { return trapType; }
            set { trapType = Char.ToUpper(value); }
        }
        public string TrapCity
        {
            get { return trapCity; }
            set { trapCity = value; }
        }
        public string TrapStreet
        {
            get { return trapStreet; }
            set { trapStreet = value; }
        }
        public string TrapState
        {
            get { return trapState; }
            set { trapState = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }


        // special method to handle storing the report time
        public void recordReportTime()
        {
            // get server time
            DateTime currentDate = DateTime.Now;

            // use elapsed time in seconds from start to current
            //reportTime = (currentDate - startTime).TotalSeconds;
            reportTime = Convert.ToInt64((currentDate - startTime).TotalSeconds);

            // 5 days = 432000 seconds
            // establish expireTime 5 days from reportTime
            expireTime = reportTime + 432000;
        }
    }
}