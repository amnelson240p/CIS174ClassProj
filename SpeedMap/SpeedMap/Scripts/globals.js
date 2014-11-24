var map;
var marker;
var myLng;
var myLat;
var nowTime;
var recordCount = null;
var rData;
var NumNewReports;
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

function setNumNewReports(num) {
    NumNewReports = num;
}