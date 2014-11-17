using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedMap.App_Code
{
    public class DisplayReport
    {
        
        private double latitude;
        private double longitude;
        private string street;
        private string city;
        private string trapType;
        private int reportTime;


        public DisplayReport()
        {
        }

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string TrapType
        {
            get { return trapType; }
            set { trapType = value; }
        }

        public int ReportTime
        {
            get { return reportTime; }
            set { reportTime = value; }
        }
    }
}