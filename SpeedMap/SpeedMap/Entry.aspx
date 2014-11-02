<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Entry.aspx.cs" Inherits="SpeedMap.Entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/entry.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <section>
        <h1>Location</h1>
        <p id="testing"></p>
        
        <asp:HiddenField ID="hfLongitude" runat="server" />
        <asp:HiddenField ID="hfLatitude" runat="server" />
        <asp:HiddenField ID="hfStreet" runat="server" />
        <asp:HiddenField ID="hfCity" runat="server" />
        <asp:HiddenField ID="hfState" runat="server" />
        <asp:HiddenField ID="hfTrapType" runat="server" />
        <asp:HiddenField ID="hfUsername" runat="server" />
        <div id="map-canvas"></div>


    </section>
    <footer>
        <img src="images/toggle_mobile.png" alt="toggle button" id="imgToggle" onclick="toggle()" class="btnToggle" />
        <button type="button" onclick="sendReportData()" class="btnReport">Report Trap</button>
        <div hidden="hidden">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btnReport" />
        </div>
    </footer>

    <script src="Scripts/jquery-2.1.1.min.js"></script>
    <script src="Scripts/geo.js"></script>
    <script src="//maps.googleapis.com/maps/api/js?"></script>
    <script src="Scripts/EntryScript.js"></script>
    <script src="Scripts/revgeocode.js"></script>
    <script>
        var trapLat;
        var trapLng;
       
        function sendReportData() {
            store_marker();
            trapLat = parseFloat(sessionStorage.getItem("trapLat"));
            trapLng = parseFloat(sessionStorage.getItem("trapLng"));
            // run geocode
            doReverse(trapLng, trapLat);
        }
    </script>
</asp:Content>

