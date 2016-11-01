function createPost() {
    var data = {
        content: $('#txtaContent').val()   
    }

    $.ajax({
        url: CreatePostUrl,
        data: data,
        type: 'GET',
        success: function () {
            reload();
        }
    });
};

function createComment(postID, btnComment) {
    var result = $('#txtaComment_'.concat(btnComment.value)).val();

    if (result.trim() != "") {
        var data = {
            postID: postID,
            content: $("#txtaComment_".concat(btnComment.value)).val()
        }

        $.ajax({
            url: CreateCommentUrl,
            data: data,
            type: 'GET',
            success: function () {
                reload();
            }
        });
    }
};

function reload() {
    $('.txtaPost').val("");
    $('.reloadView').load(ReloadViewUrl);
};
