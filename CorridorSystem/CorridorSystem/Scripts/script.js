var settings = {
    api_url: "http://localhost:5998/"
};

$("btn-login").click(function () {
    var data = {
        UserName: $("#login-user").val(),
        Password: $("#login-password").val()
    };

    console.log(data);

    $.ajax({
        url: settings + "api/Token",
        data: {
            UserName: $("#login-user").val(),
            Password: $("#login-password").val(),
            grant_type: "bearer"
        }
    }).done(function (response) {
        document.cookie = "token="+response.Token;
    });
});