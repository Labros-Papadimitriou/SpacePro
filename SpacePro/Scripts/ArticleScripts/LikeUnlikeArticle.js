// like/unlike - button
$(document).ready(function () {

    var $vars = $("#LikeUnlikeArticle\\.js").data();

    $("#like-btn").click(function () {

        if ($("#like-btn").html() == "Like") {
            $("#like-btn").html('Unlike');
            $("#like-btn").attr('class', "btn btn-outline-danger");

            $.ajax({
                url: `/Article/GiveLike?articleId=${$vars.articleId}`,
                dataType: 'json',
                type: 'get',
                success: function (articleLikes) {
                    $("#article-likes").html(articleLikes + " people like this article");
                }
            });
        }
        else {
            $("#like-btn").html('Like');
            $("#like-btn").attr('class', "btn btn-outline-success");


            $.ajax({
                url: `/Article/RemoveLike?articleId=${$vars.articleId}`,
                dataType: 'json',
                type: 'get',
                success: function (articleLikes) {
                    $("#article-likes").html(articleLikes + " people like this article");
                }
            });
        }
    });
})
