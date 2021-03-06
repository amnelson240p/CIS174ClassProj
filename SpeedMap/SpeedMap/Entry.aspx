﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Entry.aspx.cs" Inherits="SpeedMap.Entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/entry.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <section>
        <p>Toggle Mobile/Fixed. Drag marker to adjust. Press report to submit.</p>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        
        <asp:HiddenField ID="hfLongitude" runat="server" />
        <asp:HiddenField ID="hfLatitude" runat="server" />
        <asp:HiddenField ID="hfStreet" runat="server" />
        <asp:HiddenField ID="hfCity" runat="server" />
        <asp:HiddenField ID="hfState" runat="server" />
        <asp:HiddenField ID="hfTrapType" runat="server" />
  
        <div id="map-canvas"></div>


    </section>
    <footer>
        <img src="images/toggle_mobile.png" alt="toggle button" id="imgToggle" onclick="toggle()" class="btnToggle" />
        <button type="button" onclick="store_marker();return false;" class="btnReport btnRegistration">Report Trap</button>
        <div hidden="hidden">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btnReport" />
        </div>
    </footer>
    <script src="Scripts/mapstuff.js"></script>
    <script src="Scripts/jquery-2.1.1.min.js"></script>
    <script src="Scripts/reportcom.js"></script>
    <script src="Scripts/revgeocode.js"></script>
    <script src="Scripts/EntryScript.js"></script>
    <script src="Scripts/geo.js"></script>
    <script src="//maps.googleapis.com/maps/api/js?"></script>
    <script>
        var btnSubmitID = "<%=btnSubmit.ClientID%>";
    </script>
    
</asp:Content>

