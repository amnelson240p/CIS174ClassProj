<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Feed.aspx.cs" Inherits="SpeedMap.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/feed.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <section>
        <div id="jsOutput"></div>
    </section>
    <script src="Scripts/maintainfeedpage.js"></script>
    <script src="Scripts/reportcom.js"></script>
    <script src="Scripts/jquery-2.1.1.min.js"></script>   
    <script src="Scripts/locationdistance.js"></script>
    <script src="Scripts/geo.js"></script>
	<script type="text/javascript">
	    var rData;
	    var recordCount = null;

	    grabMyReports(); // also intiates building the html

	    window.onload = function () {

	        track_location();

	    }
	    window.setInterval(function () {
	        // updating distance and report ages every minute
	        updateTimes();
	        updateDistance();
	    }, 60000);


	</script>
</asp:Content>
