var userMarker;

function loadMapMarker(markers) {
	// markers array from database
    var newestReportTime = 0;

	//this loops through an array of data creating markers
    for (i = 0; i < markers.length; i++) {

        // keeps track of newest report retreived *** Added Aaron Nelson
        if (markers[i].ReportTime > newestReportTime) {
            // update most recent time
            newestReportTime = markers[i].ReportTime;
        }
        

        //set position
        var myLatlng = new google.maps.LatLng(markers[i].Latitude, markers[i].Longitude);
        var indexMarker = new google.maps.Marker(
            {
                position: myLatlng
            }
         );

        // set marker icon - always assume it is mobile
        var markericon = iconimage.mobile;
        if (markers[i].TrapType == 'F') {
            //markericon = markerfixedicon;
            markericon = iconimage.fixed;
        };
       
        //set the marker
        indexMarker.setIcon(markericon);
        indexMarker.setMap(map);
    } // end for

    // store the most recent time in session ** Added Aaron Nelson
    sessionStorage.NewestTime = newestReportTime;
    console.log("newest: " + newestReportTime);
}

function loadMapPageMap() {
	// zoom is 15
	var tmpOptions = createMap(myLat, myLng, 15);

	//create and set a marker for the center
	userMarker = createNonDragMarker(centermarker, "You",  tmpOptions);

}