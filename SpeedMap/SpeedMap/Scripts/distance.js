function get_distance(lat, lng) {
    // uses Havershine Formula as applied by Andrew Hedges
    // from andrew.hedges.name/experiments/
    var Rm = 3961;
    var lat1 = deg2rad(lat);
    var lat2 = deg2rad(myLatitude);
    var lon1 = deg2rad(lng);
    var lon2 = deg2rad(myLongitude);

    // find the differences between the coordinates
    var dlat = lat2 - lat1;
    var dlon = lon2 - lon1;

    var a = Math.pow(Math.sin(dlat / 2), 2) + Math.cos(lat1) * Math.cos(lat2) * Math.pow(Math.sin(dlon / 2), 2);
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    var dm = c * Rm;

    // round results
    var mi = round(dm);

    return mi;
}
// convert degrees to radians
function deg2rad(deg) {
    rad = deg * Math.PI / 180; // radians = degrees * pi/180
    return rad;
}


// round to the nearest 1/1000
function round(x) {
    return Math.round(x * 1000) / 1000;
}

