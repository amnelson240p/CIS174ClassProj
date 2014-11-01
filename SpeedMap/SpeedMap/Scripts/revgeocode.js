var geocoder;
var post_url = 'http://www.mapquestapi.com/geocoding/v1/reverse?key=APP_KEY&callback=renderReverse';
var safe = '';
var APP_KEY = "Fmjtd%7Cluurnua2n0%2Cbw%3Do5-9w8516"; // mapquest app key



function showReverseURL() {
    // grab locations from asp.net controls TESTING ****
    var longitude = document.getElementById("formPlaceHolder_lblLongitude").innerText;
    var latitude = document.getElementById("formPlaceHolder_lblLatitude").innerText;
    // Testing ********
    
    safe = post_url;
    safe += '&location=' + latitude + ',' + longitude; // key value pair
    

};

function doReverse() {
    document.getElementById('reverseNarrative').innerHTML = '';
    var script = document.createElement('script');
    script.type = 'text/javascript';
    showReverseURL();
    var newURL = safe.replace('APP_KEY', APP_KEY);
    document.getElementById("formPlaceHolder_lblLocation3").innerHTML = newURL;
    script.src = newURL;
    document.body.appendChild(script);
};

function renderReverse(response) {
    var html = '';

    html = "<p>Location: ";
    var location = response.results[0].locations[0];
    html += location.street + ", " + location.adminArea5 + ", " + location.adminArea4 + ", " + location.adminArea3 + ", " + location.adminArea1;
    html += "</p>";
    document.getElementById("formPlaceHolder_lblLocation1").innerHTML = location.street;
    document.getElementById("formPlaceHolder_lblLocation2").innerHTML = location.adminArea5;
    document.getElementById("formPlaceHolder_lblLocation3").innerHTML = location.adminArea3;
    document.getElementById('reverseNarrative').innerHTML = html;
}
