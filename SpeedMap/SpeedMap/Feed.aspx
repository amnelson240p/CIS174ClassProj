<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Feed.aspx.cs" Inherits="SpeedMap.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/feed.css" rel="stylesheet" />
    <script src="Scripts/locationdistance.js"></script>
    <script>track_location();</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <section>
        <div id="jsOutput"></div>
        <!-- jsOutput is the target of the built HTML -->

    </section>
    <footer>
        <div class="notification" id="notificationDiv" style="visibility:hidden">
            <label id="trapNotifications" title="New Reports"></label>
        </div>
        <asp:ImageButton ID="ibtnRefresh" runat="server" OnClick="ibtnRefresh_Click" AlternateText="Refresh" ImageUrl="~/images/Refresh2.png" CssClass="btnRefresh" ToolTip="Press to refresh page" />
    </footer>
    <script src="Scripts/maintainfeedpage.js"></script>
    <script src="Scripts/reportcom.js"></script>
    <script src="Scripts/jquery-2.1.1.min.js"></script>
    <script src="Scripts/geo.js"></script>
    <script type="text/javascript">
        var ibtnRefreshID = "<%=ibtnRefresh.ClientID%>";
        window.setTimeout(function () {
            // delayed to allow for first watchposition callback
            if (!myLat) {
                if (sessionStorage.myLat != null) {
                    myLatSet(sessionStorage.myLat);
                    myLngSet(sessionStorage.myLng);

                    //grabMyReports(); // also intiates building the html
                    grabLocalReports();
                }
                else {
                    // no location
                    alert("no location");
                }
            } else {
                // store locations for any postback
                sessionStorage.myLat = myLat;
                sessionStorage.myLng = myLng;
                //grabMyReports(); // also intiates building the html
                grabLocalReports();
            }
        }, 500);

        function updateNotifications() {
            // call function passing lat, lng, nowTime
            grabNewReportNumbers();
            
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
            // updating distance and report ages every minute
            updateTimes();
            updateDistance();
        }, 60000);


    </script>
</asp:Content>
