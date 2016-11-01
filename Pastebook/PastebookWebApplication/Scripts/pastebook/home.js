// source: http://stackoverflow.com/questions/4644027/how-to-automatically-reload-a-page-after-a-given-period-of-inactivity

setInterval(function () { autoloadpage(); }, 60000);

function autoloadpage() {
    $.ajax({
        url: ReloadViewUrl,
        type: "POST",
        success: function (data) {
            $(".reloadView").html(data);
        }
    });
};
