<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Entry.aspx.cs" Inherits="SpeedMap.Entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/entry.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <h1>Location</h1>
        <p id="testing"></p>
        <p id="longitude"></p>
        <p id="latitude"></p>
        <p id="timestamp"></p>
        <%-- <asp:Button ID="btnUpdate" runat="server" Text="Update" />--%>
        <div id="map-canvas"></div>
        <label for="mlong">Marker lng</label>
        <p id="mlong"></p>
        <label for="mlat">Marker lat</label>
        <p id="mlat"></p>
        <p id="dist"></p>
        <button type="button" onclick="lookup_location()">Update</button>
        <button type="button" onclick="store_marker()">Store</button>
    </section>


    <script src="Scripts/geo.js"></script>
    <script src="Scripts/modernizr-2.8.3.js"></script>
    <script src="//maps.googleapis.com/maps/api/js?"></script>
    <script>
        var marker;
        var map;

        function lookup_location() {

            //if (Modernizr.geolocation) {
            //    document.getElementById("testing").innerHTML = "inside if";
            //    navigator.geolocation.getCurrentPosition(show_map);
            //    //var wpnum = watchPosition(show_map, handle_error);
            //}
            if (geo_position_js.init()) {
                document.getElementById("testing").innerHTML = "inside if";
                geo_position_js.getCurrentPosition(success_callback, error_callback, { enableHighAccuracy: true });
            }
            else {
                document.getElementById("testing").innerHTML = "location is unavailable";
            }
        }

        function success_callback(position) {
            var latitude = position.coords.latitude.toFixed(4);
            var longitude = position.coords.longitude.toFixed(4);
            var time = new Date(position.timestamp);

            // store current location in session state
            sessionStorage.setItem("myLat", String(latitude));
            sessionStorage.setItem("myLng", String(longitude));

            updateMap(latitude, longitude);

            document.getElementById("longitude").innerHTML = String(longitude);
            document.getElementById("latitude").innerHTML = String(latitude);
            document.getElementById("timestamp").innerHTML = time;
        }
        function error_callback(err) {
            if (err.code == 1) {
                // user said no
                document.getElementById("testing").innerHTML = "User location denied";
            }
            else if (err.code == 2) {
                // unavailable
                document.getElementById("testing").innerHTML = "User location unavailable";
            }
        }
        function updateMap(lat, lng) {
            var image = 'images/SpeedTrapIcon.png';
            var mapOptions = { zoom: 15, center: new google.maps.LatLng(lat, lng) };
            map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
            marker = new google.maps.Marker({ map: map, position: mapOptions.center, draggable: true, title: "Spotted Trap", icon: image });

        }
        function store_marker() {
            document.getElementById("testing").innerHTML = "Storing marker";
            var mlat = marker.getPosition().lat().toFixed(4);
            var mlong = marker.getPosition().lng().toFixed(4);

            // calculate distance here
            var distance = get_distance();
            document.getElementById("dist").innerHTML = String(distance);

            document.getElementById("mlong").innerHTML = String(mlong);
            document.getElementById("mlat").innerHTML = String(mlat);
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

    </script>
</asp:Content>

