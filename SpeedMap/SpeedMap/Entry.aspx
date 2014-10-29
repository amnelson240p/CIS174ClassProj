﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Entry.aspx.cs" Inherits="SpeedMap.Entry" %>

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
        <asp:Label ID="lblReportTime" runat="server" Text="Report Time"></asp:Label>
        <br />
        <asp:Label ID="lblExpireTime" runat="server" Text="Expire Time"></asp:Label>
        <%-- <asp:Button ID="btnUpdate" runat="server" Text="Update" />--%>
        <div id="map-canvas"></div>
        <label for="mlong">Marker lng</label>
        <p id="mlong"></p>
        <label for="mlat">Marker lat</label>
        <p id="mlat"></p>
        <p id="dist"></p>
        <%--<button type="button" onclick="lookup_location()">Update</button>--%>
        <button type="button" onclick="store_marker()">Report Trap</button>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"  />
    </section>


    <script src="Scripts/geo.js"></script>
    <script src="//maps.googleapis.com/maps/api/js?"></script>
    <script src="Scripts/EntryScript.js"></script>
</asp:Content>

