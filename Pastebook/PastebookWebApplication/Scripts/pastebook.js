$(document).ready(function () {

    $('#btnRegister').click(function () {
        var data = {
            email: '#txtEmailAddress',
            username: '#txtUsername'
        }

        //test
        var text = $('.form-control').val();
        $.trim(text);

        $.ajax({
            url: CheckEmailUrl,
            data: data.email,
            type: 'POST',
            success: function (data) {
                CheckEmail(data);
            }
        })

        $.ajax({
            url: CheckUsernameUrl,
            data: data.username,
            type: 'POST',
            success: function (data) {
                CheckUsername(data);
            }
        })

        function CheckEmail(data) {
            if (data.Result == true) {
                $('#msgEmailAddress').show();
            }
        }

        function CheckUsername(data) {
            if (data.Result == true) {
                $('#msgUsername').show();
            }
        }
    })

    //test
    $('#btnLogIn').click(function () {
        var data = $('.form-control').val();
        $.trim(data);
    })
});