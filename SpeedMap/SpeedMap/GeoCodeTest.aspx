<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GeoCodeTest.aspx.cs" Inherits="SpeedMap.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/entry.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <h1>GeoCode Test</h1>
    <div class="testGroup">
        <label>Street</label>
        <asp:Label ID="lblLocation1" runat="server" Text="location 1"></asp:Label>
    </div>
    <div class="testGroup">
        <label>City</label>
        <asp:Label ID="lblLocation2" runat="server" Text="location 2"></asp:Label>
    </div>
    <div class="testGroup">
        <label>State</label>
        <asp:Label ID="lblLocation3" runat="server" Text="location 3"></asp:Label>
    </div>
    <div id="reverseNarrative"></div>
    <button type="button" onclick="doReverse()">Find</button>

    <script src="//maps.googleapis.com/maps/api/js?"></script>
    <script>
        var geocoder;
        var HOST_URL = 'http://www.mapquestapi.com';
        var SAMPLE_POST_REVERSE = HOST_URL + '/geocoding/v1/reverse?key=YOUR_KEY_HERE&callback=renderReverse';
        var safe = '';
        var APP_KEY = "Fmjtd%7Cluurnua2n0%2Cbw%3Do5-9w8516"; // mapquest app key

        function initialize() {
            document.getElementById("formPlaceHolder_lblLocation2").innerHTML = "initialized";
            geocoder = new google.maps.Geocoder();
            var latlng = new google.maps.LatLng(41.9770425, -93.57034704); 

            geocoder.geocode({ 'latLng': latlng }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    if (results[1]) {
                        document.getElementById("formPlaceHolder_lblLocation1").innerHTML = results[1].formatted_address;
                        //infowindow.setContent(results[1].formatted_address);
                        //infowindow.open(map, marker);
                    } else {
                        alert('No results found');
                    }
                } else {
                    alert('Geocoder failed due to: ' + status);
                }
            });
        }
        // ************ MapQuest below here ***********************
        function showReverseURL() {
            //var latitude = document.getElementById('lat').value;
            //var longitude = document.getElementById('lng').value;
            var latitude = 41.73129375; // hardcode test
            var longitude = -93.57790014; // hardcode test
            //var reverseFormat = document.getElementById('reverseFormat').value;
            var reverseFormat = "kvp"; // hard code test
            safe = SAMPLE_POST_REVERSE;
            switch (reverseFormat) {
                case "kvp":
                    safe += '&location=' + latitude + ',' + longitude;
                    break;
                case "json":
                    safe += '&json={';
                    safe += 'location:{latLng:{lat:' + latitude + ',lng:' + longitude + '}}}';
                    break;
                case "xml":
                    safe += '&xml='
                    safe += '<reverse><location>';
                    safe += '<latLng><lat>' + latitude + '</lat><lng>' + longitude + '</lng></latLng>';
                    safe += '</location></reverse>';
                    break;
            }
            
        };

        function doReverse() {
            //document.getElementById("formPlaceHolder_lblLocation2").innerHTML = "MapQuest";
            document.getElementById('reverseNarrative').innerHTML = '';
            var script = document.createElement('script');
            script.type = 'text/javascript';
            showReverseURL();
            var newURL = safe.replace('YOUR_KEY_HERE', APP_KEY);
            document.getElementById("formPlaceHolder_lblLocation3").innerHTML = newURL;
            script.src = newURL;
            document.body.appendChild(script);
        };

        function renderReverse(response) {
            var html = '';
            var i = 0;
            var j = 0;

            html = "<p>Location: ";
            var location = response.results[0].locations[0];
            html += location.street + ", " + location.adminArea5 + ", " + location.adminArea4 + ", " + location.adminArea3 + ", " + location.adminArea1;
            html += "</p>";
            document.getElementById("formPlaceHolder_lblLocation1").innerHTML = location.street;
            document.getElementById("formPlaceHolder_lblLocation2").innerHTML = location.adminArea5;
            document.getElementById("formPlaceHolder_lblLocation3").innerHTML = location.adminArea3;
            document.getElementById('reverseNarrative').innerHTML = html;
        }

    </script>
</asp:Content>
