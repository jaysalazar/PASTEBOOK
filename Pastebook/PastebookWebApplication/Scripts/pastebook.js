$(document).ready(function () {

    $('#btnRegister').click(function () {

        var data = {
            email: $('#txtEmailAddress').val(),
            username: $('#txtUsername').val()
        };

        $.ajax({
            url: CheckEmailUrl,
            data: data.email,
            type: 'GET',
            success: function (data) {
                CheckEmail(data);
            }
        });

        $.ajax({
            url: CheckUsernameUrl,
            data: data.username,
            type: 'GET',
            success: function (data) {
                CheckUsername(data);
            }
        });

        var passwords = {
            password: $('#txtPassword').val(),
            confirmPassword: $('#txtConfirmPassword').val()
        };

        $.ajax({
            url: ConfirmPasswordUrl,
            data: passwords,
            type: 'GET',
            success: function (data) {
                ConfirmPassword(data);
            }
        });

        function CheckEmail(data) {
            if (data.Result == true) {
                $('#spnEmailAddress').show();
            }
        }

        function CheckUsername(data) {
            if (data.Result == true) {
                $('#spnUsername').show();
            }
        }

        function ConfirmPassword(data) {
            if (data.Result == true) {
                $('#spnConfirmPassword').show();
            }
        }

    });

    // settings

    $('#aEditInfo').on('click', function () {
        $('.frmViewInfo').hide();
        $('#aEditInfo').hide(); //show on button submit
    });

    $('#aEditEmail').on('click', function () {
        $('#aEditEmail').hide(); //show on button submit
    });

    $('#aEditPassword').on('click', function () {
        $('#aEditPassword').hide(); //show on button submit
    });
});