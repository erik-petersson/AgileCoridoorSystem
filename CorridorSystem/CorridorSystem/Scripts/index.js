$(function () {
    $("#btn-login").click(function () { index_event_handlers.on_click_login(); })
    $("#btn-register").click(function () { index_event_handlers.on_click_register(); })
});

var index_event_handlers = {
    on_click_login: function () {
        var user_name = $("#login-user").val();
        var password = $("#login-password").val();
        var data = {
            UserName: user_name,
            Password: password
        };

        console.log(data);
    },

    on_click_register: function () {
        var user_name = $("#UserName").val();
        var password = $("#Password").val();
        var confirm_password = $("#ConfirmPassword").val();
        var title = $("#Title").val();
        var user_type = $("#UserType").val();
        var email = $("#Email").val();
        var first_name = $("#FirstName").val();
        var last_name = $("#LastName").val();

        var data = {
            UserName: user_name,
            Password: password,
            ConfirmPassword: confirm_password,
            Title: title,
            Email: email,
            FirstName: first_name,
            LastName: last_name
        };

        console.log(data);
    }
};