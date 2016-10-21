$(document).ready(function () {

    $('#btnRegister').click(function () {

        var data = {
            email: '#txtEmailAddress',
            username: '#txtUsername'
        }

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
                $('#spnEmailAddress').show();
            }
        }

        function CheckUsername(data) {
            if (data.Result == true) {
                $('#spnUsername').show();
            }
        }
    })

    $('#btnPost').click(function () {
        var data = {
            content: '#txtContent'
        }

        $.ajax({
            url: GetPostUrl,
            data: data,
            type: 'POST',
            success: function (data) {
                alert('success');
                location.reload();
            }
        })

        function GetPost(data) {
            //do something
        }
    })
});