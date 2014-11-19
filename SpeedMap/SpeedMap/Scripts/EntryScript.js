var toggleState = 'M';
//sessionStorage.setItem("toggleState", toggleState);

document.getElementById("formPlaceHolder_hfTrapType").value = toggleState; // store default to start

function toggle() {
    var image = document.getElementById("imgToggle");

    if (toggleState == 'M') {
        image.src = "images/toggle_fixed.png";
        toggleState = 'F';
        switchMarker(toggleState);
        // need code to store toggle state for postback
        //sessionStorage.setItem("toggleState", toggleState);
    } else {
        image.src = "images/toggle_mobile.png";
        toggleState = 'M';
        switchMarker(toggleState);
        // need code to store toggle state for postback
        //sessionStorage.setItem("toggleState", toggleState);    
    }
    // use hidden field to store toggle state
    document.getElementById("formPlaceHolder_hfTrapType").value = toggleState;
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
    var latitude = position.coords.latitude;
    var longitude = position.coords.longitude;

    loadMap(latitude, longitude);
}

function error_callback(err) {
    if (err.code == 1) {
        // user said no
        alert("User location denied");
    }
    else if (err.code == 2) {
        // unavailable
        alert("User location unavailable");
    }
}
function loadMap(lat, lng) {
    //var image = 'images/SpeedTrapIcon.png';
    //marker = new google.maps.Marker({ map: map, position: mapOptions.center, draggable: true, title: "Spotted Trap", icon: image });
    var mapOptions = createMap(lat, lng, 15);
    // parameters src, title, map options (only need center really)
    marker = createDragMarker(iconimage.mobile, "Spotted trap", mapOptions);

}
function store_marker() {
    // grab position from marker - global marker
    var markerPos = getMarkerPostion(marker);
    var mlat = markerPos.lat;
    var mlong = markerPos.lng;

    // store values in fields
    document.getElementById("formPlaceHolder_hfLongitude").value = mlong;
    document.getElementById("formPlaceHolder_hfLatitude").value = mlat;
    doReverse();
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