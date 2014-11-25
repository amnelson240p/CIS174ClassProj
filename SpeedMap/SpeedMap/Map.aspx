<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="SpeedMap.Map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/entry.css" rel="stylesheet" />
    <link href="css/feed.css" rel="stylesheet" />
    <script src="Scripts/locationdistance.js"></script>
    <script>track_location();</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <section>
        <div id="map-canvas"></div>
    </section>
    <footer>
        <div class="notification" id="notificationDiv" style="visibility:hidden">
            <label id="trapNotifications" title="New Reports"></label>
        </div>
        <asp:ImageButton ID="ibtnRefresh" runat="server" OnClick="ibtnRefresh_Click" AlternateText="Refresh" ImageUrl="~/images/Refresh2.png" CssClass="btnRefresh" ToolTip="Press to refresh page" />
    </footer>
    <script src="Scripts/jquery-2.1.1.min.js"></script>
    <script src="Scripts/mapstuff.js"></script>
    <script src="//maps.googleapis.com/maps/api/js?"></script>
    <script src="Scripts/reportcom.js"></script>
    <script src="Scripts/jeffmap.js"></script>
    <script>
        var testLng;
        var testLat;
        window.setTimeout(function () {
            // delayed to allow for first watchposition callback
            if (!myLat) {
                if (sessionStorage.myLat != null) {
                    myLatSet(sessionStorage.myLat);
                    myLngSet(sessionStorage.myLng);

                    // load the map onto page
                    loadMapPageMap();
                    // get trap locations for markers
                    grabLocalMarkerLocations();
                    
                }
                else {
                    // no location
                    alert("no location");
                }
            } else {
                // store locations for any postback
                sessionStorage.myLat = myLat;
                sessionStorage.myLng = myLng;
                testLng = myLng;
                testLat = myLat;
                // load map
                loadMapPageMap();

                
                // get trap locations for markers
                grabLocalMarkerLocations();
            }
        }, 500);

        function updateNotifications() {
            // call function passing lat, lng, nowTime
            grabNewMarkerNumbers();

        }

        window.setInterval(function () {
            // periodically search for new reports closeby
            updateNotifications();
            // limit num new reports to 5 before forcing refresh
            if (NumNewReports > 5) {
                // before we post store locations
                sessionStorage.myLat = myLat;
                sessionStorage.myLng = myLng;
                document.getElementById(ibtnRefreshID).click(); // postback
            }
        }, 10000);

        window.setInterval(function () {
            testLng -= 0.0005;
        }, 1000);
        
        window.setInterval(function () {
            
            // center map to user
            updateMapCenter(myLat, myLng);
            //updateMapCenter(testLat, testLng);
        }, 5000);
        
    </script>
</asp:Content>
