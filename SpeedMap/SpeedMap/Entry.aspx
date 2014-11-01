<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Entry.aspx.cs" Inherits="SpeedMap.Entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/entry.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <section>
        <h1>Location</h1>
        <p id="testing"></p>
        <asp:TextBox ID="txtLongitude" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtLatitude" runat="server"></asp:TextBox>
        <br />

        <div id="map-canvas"></div>


    </section>
    <footer>
        <img src="images/toggle_mobile.png" alt="toggle button" id="imgToggle" onclick="toggle()" class="btnToggle" />
        <button type="button" onclick="store_marker()">Report Trap</button>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </footer>


    <script src="Scripts/geo.js"></script>
    <script src="//maps.googleapis.com/maps/api/js?"></script>
    <script src="Scripts/EntryScript.js"></script>
    <script>
        // start in fixed toggle state
        var toggleState = 'm';

        function toggle() {
            var image = document.getElementById("imgToggle");

            if (toggleState == 'm') {
                image.src = "images/toggle_fixed.png";
                toggleState = 'f';
                switchMarker(toggleState);
                // need code to store toggle state for postback

            } else {
                image.src = "images/toggle_mobile.png";
                toggleState = 'm';
                switchMarker(toggleState);
                // need code to store toggle state for postback

            }
        }
    </script>
</asp:Content>

