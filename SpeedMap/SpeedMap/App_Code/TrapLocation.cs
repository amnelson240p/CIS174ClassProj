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

       

        public TrapLocation() {
             // start measuring time from Jan 1, 2014
        startTime = new DateTime(2014, 1, 1);
        }

       // properties
        public long reportTime { get; set;}
        public double trapLatitude { get; set; }
        public double trapLongitude { get; set; }
        public long ExpireTime
        {
            get { return expireTime; }
        }

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