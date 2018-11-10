/// <reference path="jquery-1.7.1.js" />
/// <reference path="jquery-1.7.1.min.js" />
/// <reference path="jquery-1.7.1.intellisense.js" />

$(".post .toggle-body").click(function () {
    $(this).next(".body").slideToggle("normal");
    return false;
});




    $(".approve").click(function () {
        var postIdToApprove = $(this).attr("data-id");

        $.post(
            "/forum/approvepost",
            { postId: postIdToApprove },
            function (data) {
                $("#post-" + data.object.postId).fadeOut("normal", function () {
                    $(this).remove();
                });
            },
            "json");
        return false;
    });


$(".post .admin .remove").click(function () {
    var postId = $(this).attr("meta:id");

    $.post(
        "/Forum/RemovePost",
        { postId: postId },
        function (data) {
            $("#post-" + data.object.postId)
                .fadeOut("normal", function () {
                    $(this).remove();
                });
        },
        "json"
        );
    return false;
});

//$(function () {
//    $(".admin").mouseover(function () {
//        $(this).css("color", "green");
//    });
//});

// ------------------ Save New Post -------------------------
function saveFailed() {
    $("#response").html("Sorry there is somthing error");
}

function saveComplete() {
    $("#progress").show();
}

function hideImage() {
    $("#progress").hide();
}