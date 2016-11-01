$(document).ready(function () {

    $('#txtUsernameRegister').on('blur', function () {
        var data = {
            username: $('#txtUsernameRegister').val(),
        }

        $.ajax({
            url: CheckUsernameUrl,
            data: data,
            type: 'GET',
            success: function (data) {
                CheckUsername(data);
            }
        });

        function CheckUsername(data) {
            if (data.Result == true) {
                $('#spnUsernameRegister').show();
            } else {
                $('#spnUsernameRegister').hide();
            }
        };
    });

    $('#txtEmailRegister').on('blur', function () {
        var data = {
            email: $('#txtEmailRegister').val(),
        }

        $.ajax({
            url: CheckEmailUrl,
            data: data,
            type: 'GET',
            success: function (data) {
                CheckEmail(data)
            }
        });

        function CheckEmail(data) {
            if (data.Result == true) {
                $('#spnEmailRegister').show();
            } else {
                $('#spnEmailRegister').hide();
            }
        };
    });

    $('#txtConfirmPasswordRegister').on('blur', function () {
        var data = {
            password: $('#txtPasswordRegister').val(),
            confirm: $('#txtConfirmPasswordRegister').val(),
        }

        if (data.password != data.confirm) {
            $('#spnConfirmPasswordRegister').show();
        } else {
            $('#spnConfirmPasswordRegister').hide();
        }
    });
});