// delete article
$(document).ready(function () {
    $("#delete-btn").click(function () {

        var $vars = $("#DeleteArticle\\.js").data();

        $.ajax({
            url: `/Article/DeleteArticle?articleId=${$vars.articleId}&imageId=${$vars.articleImageId}`,
            type: "delete",
            dataType: "json",
            success: function (path) {
                window.location.href = path;
            }
        })
    })
})
