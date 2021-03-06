﻿var geocoder;
var post_url = 'http://www.mapquestapi.com/geocoding/v1/reverse?key=APP_KEY&callback=renderReverse';
var safe = '';
var APP_KEY = "Fmjtd%7Cluurnua2n0%2Cbw%3Do5-9w8516"; // mapquest app key



function showReverseURL(lng, lat) {
   
    var longitude = lng;
    var latitude = lat;
    
    safe = post_url;
    safe += '&location=' + latitude + ',' + longitude; // key value pair
};

function doReverse() {
    var lat = document.getElementById("formPlaceHolder_hfLatitude").value;
    var lng = document.getElementById("formPlaceHolder_hfLongitude").value;
    var script = document.createElement('script');
    script.type = 'text/javascript';
    showReverseURL(lng, lat);
    var newURL = safe.replace('APP_KEY', APP_KEY);
    script.async = true;
    script.src = newURL;
        
    document.body.appendChild(script);
    
    //var first = document.getElementsByTagName('script')[0];
    //first.parentNode.insertBefore(script, first);
    
};


function renderReverse(response) {   
    var location = response.results[0].locations[0];
    var trapLoc = {};
    trapLoc.Latitude = parseFloat(document.getElementById("formPlaceHolder_hfLatitude").value);
    trapLoc.Longitude = parseFloat(document.getElementById("formPlaceHolder_hfLongitude").value);
    trapLoc.TrapType = document.getElementById("formPlaceHolder_hfTrapType").value;
    trapLoc.Street = location.street;
    trapLoc.City = location.adminArea5;
    trapLoc.State = location.adminArea3;


    // instead of building the string on the call we'll build it (the full JSON object) before
    // with a data transfer object
    var DTO = { 'trapLoc': trapLoc }; // now we'll peform JSON.stringify(DTO) at AJAX call

    // send report data to server through calling storeData code-behind method and passing client-side values
    sendMyReport(DTO); // reportcom.js

    
}
