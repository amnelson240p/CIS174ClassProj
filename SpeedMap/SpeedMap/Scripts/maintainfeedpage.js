function createUL() {
    var out = document.getElementById("jsOutput");
    // each report record is built with this format
    // x is the index of report records
    // <div id="feedx" class="feedGroup" >
    //      <label id="feedx_rtime" style="display:none;" ></label>
    //      <label id="feedx_lat" style="display:none;"></label>
    //      <label id="feedx_lng" style="display:none;"></label>
    //      <ul>
    //          <li class="feedLoc"><p id="feedLocx"></p></li>
    //          <li class="feedDistance"><p id="feedDistancex"></p></li>
    //          <li class="feedType"><p id="feedTypex"></p></li>
    //          <li class="feedDuration"><p id="feedDuration"></p></li>
    //      </ul>
    // </div>

    // we'll keep track of newest report time client receives
    // number will be the highest of all received.
    var newestReportTime = 0; // initialize 

    // start outer loop here
    for (x = 0; x < rData.length; x++) {        
        if (rData[x].ReportTime > newestReportTime) {
            // update most recent time
            newestReportTime = rData[x].ReportTime; 
        }
        var divEle = document.createElement("div");
        divEle.className = "feedGroup";
        divEle.id = "feed" + x;
        out.appendChild(divEle);
        for (j = 0; j < lblStr.length; j++) {
            var lblEle = document.createElement("label");
            lblEle.id = "feed" + x + lblStr[j];
            lblEle.style.display = 'none';
            divEle.appendChild(lblEle);
        }

        var listElement = document.createElement("ul");
        // add to container
        divEle.appendChild(listElement);
        for (i = 0; i < classStr.length; i++) {
            var pItem = document.createElement("p");
            var listItem = document.createElement("li");

            pItem.id = classStr[i] + x;
            listItem.appendChild(pItem);
            listItem.className = classStr[i];
            listElement.appendChild(listItem);

        }
        throwData(x);
    }// end outer for

    // store the most recent time in session
    sessionStorage.NewestTime = newestReportTime;
    console.log("newest: " + newestReportTime);
}



function throwData(recIndex) {
    // using the dynamically created html structure
    // fill in html elements with known data
    document.getElementById("feed" + recIndex + lblStr[0]).innerHTML = rData[recIndex].ReportTime;
    document.getElementById("feed" + recIndex + lblStr[1]).innerHTML = rData[recIndex].Latitude;
    document.getElementById("feed" + recIndex + lblStr[2]).innerHTML = rData[recIndex].Longitude;
    var locStr = rData[recIndex].Street + ", " + rData[recIndex].City;
    document.getElementById(classStr[0] + recIndex).innerHTML = locStr;
    document.getElementById(classStr[1] + recIndex).innerHTML = "Updating...";
    var trapTypeStr;
    var trapIcon;
    if ("M".localeCompare(rData[recIndex].TrapType) == 0) {
        trapTypeStr = "Mobile";
        trapIcon = "url(images/MobileSm.png)";
    } else {
        trapTypeStr = "Fixed";
        trapIcon = "url(images/FixedSm.png)";
    }
    // stylize and initialize with browser compatible syntax
    document.getElementById(classStr[2] + recIndex).innerHTML = trapTypeStr;
    document.getElementById(classStr[2] + recIndex).style.backgroundImage = trapIcon;
    document.getElementById(classStr[2] + recIndex).style.backgroundRepeat = "no-repeat";
    document.getElementById(classStr[2] + recIndex).style.backgroundSize = "contain";
    document.getElementById(classStr[3] + recIndex).innerHTML = "calculated elapsed time";

}

function updateTimes() {
    // update time elements
    // recordCount is the number of records an element needs to be updated
    var d = new Date();
    var startDate = new Date("January 1, 2014"); // January 1, 2014
    nowTime = Math.abs(d - startDate);
    // 1000 milliseconds to 1 sec
    nowTime = Math.floor(nowTime / 1000); // round to nearest integer

    // calculate time for each feed entry
    // need to put in loop time1, time2, etc.
    var feedStr;
    var timeStr;
    for (i = 0; i < recordCount; i++) {
        feedStr = "feed" + i + "_rtime";
        timeStr = classStr[3] + i;
        var reportTime = document.getElementById(feedStr).innerHTML;
        var elapsed = convertElapsed(reportTime, nowTime);
        document.getElementById(timeStr).innerHTML = elapsed;


    }


}

function convertElapsed(old, current) {
    // create a readable format for report age
    // passed in parameters are # of seconds from Jan 1, 2014
    // old is time of report
    // current is now

    var diff = current - old;
    // one year is 31536000 seconds
    var numyears = Math.floor(diff / 31536000);
    var numdays = Math.floor((diff % 31536000) / 86400);
    var numhours = Math.floor(((diff % 31536000) % 86400) / 3600);
    var numminutes = Math.floor((((diff % 31536000) % 86400) % 3600) / 60);
    var numseconds = (((diff % 31536000) % 86400) % 3600) % 60;

    var elapseStr = "";
    if (numyears > 0) {
        elapseStr += numyears + "y, ";
    }
    if (numdays > 0) {
        elapseStr += numdays + "d, ";
    }
    if (numhours > 0) {
        elapseStr += numhours + "h, ";
    }
    if (numminutes > 0) {
        elapseStr += numminutes + "m, ";
    }
    if (numseconds > 0) {
        elapseStr += numseconds + "s ";
    }
    elapseStr += "ago."

    return elapseStr;
}

function updateDistance() {
    var lng;
    var lat;
    var dist;

    for (i = 0; i < recordCount; i++) {
        var rd = document.getElementById(classStr[1] + i);

        lat = document.getElementById("feed" + i + lblStr[1]).innerHTML;
        lng = document.getElementById("feed" + i + lblStr[2]).innerHTML;

        dist = get_distance(lat, lng) + " mi";
        //console.log("lat: " + lat + ", lng: " + lng + ", dist: " + dist);
        rd.innerHTML = dist;
    }
}