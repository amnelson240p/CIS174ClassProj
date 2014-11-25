var iconimage = {};
iconimage.fixed = "images/FixedTrapIcon.png";
iconimage.mobile = "images/SpeedTrapIcon.png";
var centermarker = "images/sportscar.png";

function createMap(lat, lng, z) {
	var mapOptions = { zoom: z, center: new google.maps.LatLng(lat, lng) };
	map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
    //alert ("map maybe made. lat: " + lat + ", lng: " + lng);
	return mapOptions;
}

function createMarkerOptions(lat, lng) {
	var markerOptions = {center: new google.maps.LatLng(lat, lng) };
	return markerOptions;
}

function createDragMarker (iconsrc, mtitle, mOptions) {
	var tmpMarker = new google.maps.Marker({ map: map, position: mOptions.center, draggable: true, title: mtitle, icon: iconsrc });
	return tmpMarker;
}

function createNonDragMarker(iconsrc, mtitle, mOptions) {
	var tmpMarker = new google.maps.Marker({ map: map, position: mOptions.center, draggable: false, title: mtitle, icon: iconsrc });
	return tmpMarker;
}

function getMarkerPostion(m) {
	// m is marker
	var mPos = {};
	mPos.lat = m.getPosition().lat();
	mPos.lng = m.getPosition().lng();
	return mPos;
}

function updateMapCenter(lat, lng) {
    var center = new google.maps.LatLng(lat, lng);
    userMarker.setPosition(center);
	map.panTo(center);
	console.log("map updated");
}
