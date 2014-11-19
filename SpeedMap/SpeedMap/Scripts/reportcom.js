function grabMyReports() {
	$.ajax({
		type: "POST",
		url: "Feed.aspx/GetData",
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		async: false,
		success: function (response) {
			traps = response.d;
	                //alert(traps);
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