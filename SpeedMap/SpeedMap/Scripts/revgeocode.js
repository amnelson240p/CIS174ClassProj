var geocoder;
var post_url = 'http://www.mapquestapi.com/geocoding/v1/reverse?key=APP_KEY&callback=renderReverse';
var safe = '';
var APP_KEY = "Fmjtd%7Cluurnua2n0%2Cbw%3Do5-9w8516"; // mapquest app key



function showReverseURL(lng, lat) {
   
    var longitude = lng;
    var latitude = lat;
    
    safe = post_url;
    safe += '&location=' + latitude + ',' + longitude; // key value pair
};

function doReverse(lng, lat) {
    var script = document.createElement('script');
    script.type = 'text/javascript';
    showReverseURL(lng, lat);
    var newURL = safe.replace('APP_KEY', APP_KEY);
    script.src = newURL;
    
    document.body.appendChild(script);
};


function renderReverse(response) {
    var html = '';
    //alert("inside renderReverse");
    html = "<p>Location: ";
    var location = response.results[0].locations[0];
    html += location.street + ", " + location.adminArea5 + ", " + location.adminArea4 + ", " + location.adminArea3 + ", " + location.adminArea1;
    html += "</p>";
    //alert(html);
    
    //document.getElementById("testing").innerHTML = html;
    

    // store needed data in session
    sessionStorage.setItem("trapCity", location.adminArea5);
    sessionStorage.setItem("trapStreet", location.street);
    sessionStorage.setItem("trapState", location.adminArea3);

    var trapLat = parseFloat(sessionStorage.getItem("trapLat"));
    var trapLng = parseFloat(sessionStorage.getItem("trapLng"));
    var trapType = sessionStorage.getItem("toggleState");
    var userName = document.getElementById("formPlaceHolder_hfUsername").value;
    var request = {lat:trapLat, lng:trapLng, street:location.street, city:location.adminArea5, state:location.adminArea3, type:trapType, username:userName };
    var strRequest = JSON.stringify(request);
    //alert(strRequest);

    // send report data to server through calling storeData code-behind method and passing client-side values
    $.ajax({
        type: "POST",
        url: "Entry.aspx/storeData",
        contentType: "application/json; charset=utf-8",
        data:strRequest,
        dataType: "json",
        success: function (response) {
        },
        
        failure: function (response) {
            alert(response.d);
        }
    });

    // finally send control back to the server through postback
    document.getElementById("formPlaceHolder_btnSubmit").click();
}
