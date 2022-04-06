//edit form pre - fill category option
$(document).ready(function () {
    $('#edit-category option[value=@Model.ArticleCategoryId]').attr('selected', '');
})

//clear edit form
$("#clear-btn").click(function () {
    $("#edit-title").val("");
    $("#edit-authorname").val("");
    $("#edit-shortdesc").val("");
    $("#edit-fulldesc").val("");
    $("#edit-title").val("");
    $('#edit-category option[value=7]').attr('selected', '');
})