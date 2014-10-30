<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EntryConfirmation.aspx.cs" Inherits="SpeedMap.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/entry.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <h1>Thank you for the report</h1>
    <h2>The location has been recorded.</h2>
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
</asp:Content>
