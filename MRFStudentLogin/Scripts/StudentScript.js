

function Loginpage() {

    var stud = {
        userid: $('#UserName').val(),
        password: $('#Password').val()

    };
    

    $.ajax({
        url: "StudentLogin/UpdateLoginStatus/",
        data: JSON.stringify(stud),
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            if (result == 1) {
                //alert("hello")
                window.location = "/MRFLogin/Index";
            }
            else {
                alert("login Failed");
            }

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

