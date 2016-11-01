$(document).ready(function () {

    $('#txtUsernameSettings').on('blur', function () {
        var data = {
            username: $('#txtUsernameSettings').val()
        }

        $.ajax({
            url: CheckUsernameUrl,
            data: data,
            type: 'GET',
            success: function (data) {
                CheckUsernameSettings(data);
            }
        });

        function CheckUsernameSettings(data) {
            if (data.Result == true) {
                $('#spnUsernameSettings').show();
            } else {
                $('#spnUsernameSettings').hide();
            }
        };
    });

    $('#txtEmailSettings').on('blur', function () {
        var data = {
            email: $('#txtEmailSettings').val()
        }

        $.ajax({
            url: CheckEmailUrl,
            data: data,
            type: 'GET',
            success: function (data) {
                CheckEmailSettings(data);
            }
        });

        function CheckEmailSettings(data) {
            if (data.Result == true) {
                $('#spnEmailSettings').show();
            } else {
                $('#spnEmailSettings').hide();
            }
        };
    });

    $('#btnEmail').on('click', function () {
        var data = {
            email: $('#txtEmailSettings').val(),
            password: $('#txtPasswordSettings').val()
        }
      
        $.ajax({
            url: CheckPasswordUrl,
            data: data,
            type: 'GET',
            success: function (data) {
                CheckPasswordSettings(data);
            }
        });

        function CheckPasswordSettings(data) {
            if (data.Result == false) {
                $('#spnPasswordSettings').show();
            } else {
                $('#spnPasswordSettings').hide();
            }
        };
    });

    $('#btnPass').on('click', function () {
        var data = {
            email: $('#txtEmailSettings').val(),
            password: $('#txtCurrentPassword').val()
        }

        $.ajax({
            url: CheckPasswordUrl,
            data: data,
            type: 'GET',
            success: function (data) {
                CheckPasswordSettings(data);
            }
        });

        function CheckPasswordSettings(data) {
            if (data.Result == false) {
                $('#spnCurrentPasswordSettings').show();
            } else {
                $('#spnCurrentPasswordSettings').hide();
            }
        };
    });

    $('#txtNewPassword').on('blur', function () {
        var data = {
            currentPassword: $('#txtCurrentPassword').val(),
            newPassword: $('#txtNewPassword').val()
        }

        if (data.currentPassword == data.newPassword) {
            $('#spnConfirmNewPassword').show();
        } else {
            $('#spnConfirmNewPassword').hide();
        }
    });

    $('#txtConfirmPasswordSettings').on('blur', function () {
        var data = {
            newPassword: $('#txtNewPassword').val(),
            confirmPassword: $('#txtConfirmPasswordSettings').val()
        }

        if (data.newPassword != data.confirmPassword) {
            $('#spnConfirmPasswordSettings').show();
        } else {
            $('#spnConfirmPasswordSettings').hide();
        }
    });

    // settings edit link on click

    $('#aEditInfo').on('click', function () {
        $('.frmViewInfo').hide();
        $('#aEditInfo').hide();
    });

    $('#aEditEmail').on('click', function () {
        $('#aEditEmail').hide();
    });

    $('#aEditPassword').on('click', function () {
        $('#aEditPassword').hide();
    });
});