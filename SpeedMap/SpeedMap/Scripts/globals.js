var map;
var marker;
var myLng;
var myLat;
var recordCount = null;
var rData;
var classStr = ["feedLoc", "feedDistance", "feedType", "feedDuration"];
var lblStr = ["_rtime", "_lat", "_lng"];

function myLngSet(lng) {
    myLng = lng;
}

function myLatSet(lat) {
    myLat = lat;
}

function setCount(c) {
    recordCount = c;
}