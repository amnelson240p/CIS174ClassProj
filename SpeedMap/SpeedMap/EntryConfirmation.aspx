<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EntryConfirmation.aspx.cs" Inherits="SpeedMap.WebForm2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/entry.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <h1 id="hConfirm" runat="server"></h1>
    <h2>The location has been recorded.</h2>
    <div class="testGroup">
        <label for="lblUsername">Username</label>
        <asp:Label ID="lblUsername" runat="server" Text="username" CssClass="reportData"></asp:Label>
    </div>
    <div class="testGroup">
        <label for="lblLongitude">Longitude</label>
        <asp:Label ID="lblLongitude" runat="server" Text="Long" CssClass="reportData"></asp:Label>
    </div>
    <div class="testGroup">
        <label for="lblLatitude">Latitude</label>
        <asp:Label ID="lblLatitude" runat="server" Text="Lat" CssClass="reportData"></asp:Label>
    </div>
    <div class="testGroup">
        <label for="lblReportTime">Report Time</label>
        <asp:Label ID="lblReportTime" runat="server" Text="rep" CssClass="reportData"></asp:Label>
    </div>
    <div class="testGroup">
        <label for="lblExpireTime">Expire Time</label>
        <asp:Label ID="lblExpireTime" runat="server" Text="exp" CssClass="reportData"></asp:Label>
    </div>
    <h1>GeoCode Test</h1>
    <div class="testGroup">
        <label>Street</label>
        <asp:Label ID="lblStreet" runat="server" Text="location 1" CssClass="reportData"></asp:Label>
    </div>
    <div class="testGroup">
        <label>City</label>
        <asp:Label ID="lblCity" runat="server" Text="location 2" CssClass="reportData"></asp:Label>
    </div>
    <div class="testGroup">
        <label>State</label>
        <asp:Label ID="lblState" runat="server" Text="location 3" CssClass="reportData"></asp:Label>
    </div>
    <div class="testGroup">
        <label>Trap Type</label>
        <asp:Label ID="lblTrapType" runat="server" Text="Type" CssClass="reportData"></asp:Label>
    </div>
    <asp:Button ID="btnMaps" runat="server" Text="Take Me To Map" OnClick="btnMaps_Click" />
    
</asp:Content>
