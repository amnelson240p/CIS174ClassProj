function grabLocalReports() {
	var loc = {};
	loc.lat = myLat;
	loc.lng = myLng;
	var requestStr = JSON.stringify(loc);

	$.ajax({
		type: "POST",
		url: "Feed.aspx/GetLocalData",
		contentType: "application/json; charset=utf-8",
		data: requestStr,
		dataType: "json",
		success: function (response) {
			traps = response.d;
	                rData = JSON.parse(traps);
	                var c = rData.length; // num of records
	                
	                setCount(c); // store count
	                createUL();
	                updateTimes();
	                window.setTimeout(function () {
            		// delayed to allow for first watchposition callback
            			updateDistance();
        			}, 1000);

	    },

	    failure: function (response) {
	        alert(response.d);
	    }
	});
}

function grabLocalMarkerLocations() {
    var loc = {};
    loc.lat = myLat;
    loc.lng = myLng;
    var requestStr = JSON.stringify(loc);

    $.ajax({
        type: "POST",
        url: "Map.aspx/GetLocalData",
        contentType: "application/json; charset=utf-8",
        data: requestStr,
        dataType: "json",
        success: function (response) {
            traps = response.d;
            rData = JSON.parse(traps);
            var c = rData.length; // num of records

            setCount(c); // store count
            loadMapMarker(rData);

        },

        failure: function (response) {
            alert(response.d);
        }
    });
}

function grabNewReportNumbers() {
    var loc = {};
    loc.lat = myLat;
    loc.lng = myLng;
    loc.now = sessionStorage.NewestTime;
    var requestStr = JSON.stringify(loc);

    $.ajax({
        type: "POST",
        url: "Feed.aspx/GetRecentReports",
        contentType: "application/json; charset=utf-8",
        data: requestStr,
        dataType: "json",
        success: function (response) {
            var numReps = parseInt(response.d);
            //console.log("got em! num reports: " + numReps);
            setNumNewReports(numReps);
            if (numReps > 0) {
                // make container visible
                document.getElementById("notificationDiv").style.visibility = "visible";
                document.getElementById("trapNotifications").innerHTML = NumNewReports;
            } else {
                // no display if 0
                // hide container
                document.getElementById("notificationDiv").style.display = "hidden";
                document.getElementById("trapNotifications").innerHTML = "";
            }

        },

        failure: function (response) {
            alert(response.d);
        }
    });
}

function grabNewMarkerNumbers() {
    var loc = {};
    loc.lat = myLat;
    loc.lng = myLng;
    loc.now = sessionStorage.NewestTime;
    var requestStr = JSON.stringify(loc);

    $.ajax({
        type: "POST",
        url: "Map.aspx/GetRecentReports",
        contentType: "application/json; charset=utf-8",
        data: requestStr,
        dataType: "json",
        success: function (response) {
            var numReps = parseInt(response.d);
            //console.log("got em! num reports: " + numReps);
            setNumNewReports(numReps);
            if (numReps > 0) {
                // make container visible
                document.getElementById("notificationDiv").style.visibility = "visible";
                document.getElementById("trapNotifications").innerHTML = NumNewReports;
            } else {
                // no display if 0
                // hide container
                document.getElementById("notificationDiv").style.display = "hidden";
                document.getElementById("trapNotifications").innerHTML = "";
            }

        },

        failure: function (response) {
            alert(response.d);
        }
    });
}
function sendMyReport(DTO) {
	$.ajax({
        type: "POST",
        url: "Entry.aspx/storeData",
        contentType: "application/json; charset=utf-8",
	    //data:"{trapLoc:" + reportStr + "}",
        data: JSON.stringify(DTO),
        dataType: "json",
        success: function (response) {
            // finally send control back to the server through postback
            document.getElementById(btnSubmitID).click();
        },
        
        failure: function (response) {
            alert(response.d);
        }
    });
}