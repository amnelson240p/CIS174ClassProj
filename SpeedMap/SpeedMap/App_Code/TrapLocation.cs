using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedMap.App_Code
{
    public class TrapLocation
    {
        private DateTime startTime;
        private double expireTime; // to be set 5 days after initial report

       

        public TrapLocation() {
             // start measuring time from Jan 1, 2014
        startTime = new DateTime(2014, 1, 1);
        }

       // properties
        public double reportTime { get; set;}
        public float trapLatitude { get; set; }
        public float trapLongitude { get; set; }
        public double ExpireTime
        {
            get { return expireTime; }
        }

        public void recordReportTime()
        {
            // get server time
            DateTime currentDate = DateTime.Now;

            // use elapsed time in seconds from start to current
            reportTime = (currentDate - startTime).TotalSeconds;

            // 5 days = 432000 seconds
            // establish expireTime 5 days from reportTime
            expireTime = reportTime + 432000;
        }
    }
}