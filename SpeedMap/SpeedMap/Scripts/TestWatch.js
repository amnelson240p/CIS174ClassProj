var marker;
var id;

function track_location() {
    if (navigator.geolocation) {
        var options = {
            enableHighAccuracy: true,
            timeout: 5000,
            maximumAge: 0
        };
        navigator.geolocation.watchPosition(successCallback, error_callback, options);
    }
    else {
        alert("Geolocation not supported");
    }
}

function success_callback(position) {
    var myLatitude = position.coords.latitude;
    var myLongitude = position.coords.longitude;

    // if we are on feed page calculate distances

    
}

function error_callback(err) {
    var errors = {
        1: 'Permission denied',
        2: 'Position unavailable',
        3: 'Request timeout'
    };
    alert("Error: " + errors[err.code]);
}

function testStuff() {
    
    // store current location in session state - for distance calculations *** test only
    sessionStorage.setItem("myLat", String(latitude));
    sessionStorage.setItem("myLng", String(longitude));

    // calculate distance here ** test purpose only *****
    var distance = get_distance();
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