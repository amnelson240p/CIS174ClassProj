function OnSuccess(response) {
    var mesg = $("#mesg")[0];
    switch (response.d) {
        case "true":
            mesg.style.color = "green";
            mesg.innerHTML = "Available";
            break;
        case "false":
            mesg.style.color = "red";
            mesg.innerHTML = "Not Available";
            break;
        case "error":
            mesg.style.color = "red";
            mesg.innerHTML = "Error occurred";
            break;
    }
}

function OnChange(txt) {
    $("#mesg")[0].innerHTML = "";
}

function OnTest(response) {
    switch (response.d) {
        case "true":
            $("#lblLoginInfo").html("");
            console.log("Not Available");
            break;
        case "false":
            $("#lblLoginInfo").html("User Doesn't exist. Would you like to register?" +
                "<br />" +
                "Press the registration button below to begin registration");
            console.log("Available");
            break;
    }
}

function CheckUsername() {
    var user = {};
    user.username = $("#txtUsername").val();
    var dataStr = JSON.stringify(user);
    console.log("user: " + user.username);

    $.ajax({
        type: "POST",
        url: "Registration.aspx/VerifyNewUser",
        contentType: "application/json; charset=utf-8",
        data: dataStr,
        dataType: "json",
        success: function (response) {
            OnTest(response);
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}