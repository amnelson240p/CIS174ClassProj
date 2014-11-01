<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EntryConfirmation.aspx.cs" Inherits="SpeedMap.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/entry.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <h1>Thank you for the report</h1>
    <h2>The location has been recorded.</h2>
    <div class="testGroup">
        <label for="lblUsername">Username</label>
        <asp:Label ID="lblUsername" runat="server" Text="username"></asp:Label>
    </div>
    <div class="testGroup">
        <label for="lblLongitude">Longitude</label>
        <asp:Label ID="lblLongitude" runat="server" Text="Long"></asp:Label>
    </div>
    <div class="testGroup">
        <label for="lblLatitude">Latitude</label>
        <asp:Label ID="lblLatitude" runat="server" Text="Lat"></asp:Label>
    </div>
    <div class="testGroup">
        <label for="lblReportTime">Report Time</label>
        <asp:Label ID="lblReportTime" runat="server" Text="rep"></asp:Label>
    </div>
    <div class="testGroup">
        <label for="lblExpireTime">Expire Time</label>
        <asp:Label ID="lblExpireTime" runat="server" Text="exp"></asp:Label>
    </div>
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


    <script src="Scripts/revgeocode.js"></script>
    <script>
        window.onload = doReverse();
    </script>
</asp:Content>
