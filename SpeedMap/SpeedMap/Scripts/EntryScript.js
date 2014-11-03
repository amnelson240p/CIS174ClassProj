
var marker;
var map;
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
    var latitude = position.coords.latitude.toFixed(4);
    var longitude = position.coords.longitude.toFixed(4);

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