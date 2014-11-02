
var marker;
var map;
var toggleState = 'M';
sessionStorage.setItem("toggleState", toggleState);

function toggle() {
    var image = document.getElementById("imgToggle");

    if (toggleState == 'M') {
        image.src = "images/toggle_fixed.png";
        toggleState = 'F';
        switchMarker(toggleState);
        // need code to store toggle state for postback
        sessionStorage.setItem("toggleState", toggleState);

    } else {
        image.src = "images/toggle_mobile.png";
        toggleState = 'M';
        switchMarker(toggleState);
        // need code to store toggle state for postback
        sessionStorage.setItem("toggleState", toggleState);
    }
}
function lookup_location() {
    if (geo_position_js.init()) {
        geo_position_js.getCurrentPosition(success_callback, error_callback, { enableHighAccuracy: true });
    }
    else {
        alert("location is unavailable");
    }
}

function success_callback(position) {
    var latitude = position.coords.latitude.toFixed(4);
    var longitude = position.coords.longitude.toFixed(4);
   

    // store current location in session state
    sessionStorage.setItem("myLat", String(latitude));
    sessionStorage.setItem("myLng", String(longitude));
    


    updateMap(latitude, longitude);

   
}
function error_callback(err) {
    if (err.code == 1) {
        // user said no
        document.getElementById("testing").innerHTML = "User location denied";
        alert("User location denied");
    }
    else if (err.code == 2) {
        // unavailable
        document.getElementById("testing").innerHTML = "User location unavailable";
        alert("User location unavailable");
    }
}
function updateMap(lat, lng) {
    var image = 'images/SpeedTrapIcon.png';
    var mapOptions = { zoom: 15, center: new google.maps.LatLng(lat, lng) };
    map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
    marker = new google.maps.Marker({ map: map, position: mapOptions.center, draggable: true, title: "Spotted Trap", icon: image });

}
function store_marker() {
   
    var mlat = marker.getPosition().lat();
    var mlong = marker.getPosition().lng();

    // store in session
    sessionStorage.setItem("trapLat", mlat);
    sessionStorage.setItem("trapLng", mlong);

    // calculate distance here
    var distance = get_distance();
    

    // testing form output
    //document.getElementById("formPlaceHolder_txtLongitude").value = String(mlong);
    //document.getElementById("formPlaceHolder_txtLatitude").value = String(mlat);

    // testing postback
    //document.getElementById("formPlaceHolder_btnSubmit").click();
}
function get_distance() {
    var Rm = 3961;
    var currentLng = parseFloat(sessionStorage.getItem("myLng"));
    var currentLat = parseFloat(sessionStorage.getItem("myLat"));
    var mlat = marker.getPosition().lat().toFixed(4);
    var mlong = marker.getPosition().lng().toFixed(4);
    var lat1 = deg2rad(mlat);
    var lat2 = deg2rad(currentLat);
    var lon1 = deg2rad(mlong);
    var lon2 = deg2rad(currentLng);

    // find the differences between the coordinates
    var dlat = lat2 - lat1;
    var dlon = lon2 - lon1;

    var a = Math.pow(Math.sin(dlat / 2), 2) + Math.cos(lat1) * Math.cos(lat2) * Math.pow(Math.sin(dlon / 2), 2);
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    var dm = c * Rm;

    // round results
    var mi = round(dm);

    return mi;
}
// convert degrees to radians
function deg2rad(deg) {
    rad = deg * Math.PI / 180; // radians = degrees * pi/180
    return rad;
}


// round to the nearest 1/1000
function round(x) {
    return Math.round(x * 1000) / 1000;
}

function switchMarker(state) {
    var image;
    
    if (state == 'F') {
        image = "images/FixedTrapIcon.png";
        //document.getElementById("testing").innerHTML = "Fixed";
    } else {
        image = "images/SpeedTrapIcon.png";
        //document.getElementById("testing").innerHTML = "mobile";
    }
    marker.setIcon(image);
}