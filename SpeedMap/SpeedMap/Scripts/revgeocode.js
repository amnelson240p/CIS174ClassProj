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
    var trapLat = document.getElementById("formPlaceHolder_hfLatitude").value;
    var trapLng = document.getElementById("formPlaceHolder_hfLongitude").value;
    var trapType = document.getElementById("formPlaceHolder_hfTrapType").value;
    var request = {lat:trapLat, lng:trapLng, street:location.street, city:location.adminArea5, state:location.adminArea3, type:trapType };
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
            // finally send control back to the server through postback
            document.getElementById("formPlaceHolder_btnSubmit").click();
        },
        
        failure: function (response) {
            alert(response.d);
        }
    });

    
}
