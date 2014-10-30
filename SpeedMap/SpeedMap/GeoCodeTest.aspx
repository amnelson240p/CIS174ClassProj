<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GeoCodeTest.aspx.cs" Inherits="SpeedMap.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/entry.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <h1>GeoCode Test</h1>
    <div class="testGroup">
        <label>Location1</label>
        <asp:Label ID="lblLocation1" runat="server" Text="location 1"></asp:Label>
    </div>
    <div class="testGroup">
        <label>Location2</label>
        <asp:Label ID="lblLocation2" runat="server" Text="location 2"></asp:Label>
    </div>
    <div class="testGroup">
        <label>Location3</label>
        <asp:Label ID="lblLocation3" runat="server" Text="location 3"></asp:Label>
    </div>
    <button type="button" onclick="initialize()">Find</button>

    <script src="//maps.googleapis.com/maps/api/js?"></script>
    <script>
        var geocoder;

        function initialize() {
            document.getElementById("formPlaceHolder_lblLocation2").innerHTML = "initialized";
            geocoder = new google.maps.Geocoder();
            var latlng = new google.maps.LatLng(41.9770425, -93.57034704); 

            geocoder.geocode({ 'latLng': latlng }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    if (results[1]) {
                        document.getElementById("formPlaceHolder_lblLocation1").innerHTML = results[1].formatted_address;
                        //infowindow.setContent(results[1].formatted_address);
                        //infowindow.open(map, marker);
                    } else {
                        alert('No results found');
                    }
                } else {
                    alert('Geocoder failed due to: ' + status);
                }
            });
        }

    </script>
</asp:Content>
