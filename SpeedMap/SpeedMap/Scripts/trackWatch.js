var myLatitude;
var myLongitude;

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
    myLatitude = position.coords.latitude;
    myLongitude = position.coords.longitude;

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
