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
        <button type="button" onclick="store_marker()">Report Trap</button>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"  />
    </section>


    <script src="Scripts/geo.js"></script>
    <script src="//maps.googleapis.com/maps/api/js?"></script>
    <script src="Scripts/EntryScript.js"></script>
</asp:Content>

