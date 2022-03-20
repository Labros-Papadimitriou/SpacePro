
var settings = {
    "url": "/AppUser/GetUserImage",
    "method": "GET",
    "timeout": 0,
};

$.ajax(settings).done(function (dataImg) {
    let temp = `<img  src="/Template/sash/assets/images/users/7.jpg" alt="profile-user" class="avatar  profile-user brround cover-image">`;


    if (dataImg.data != "") {
        temp = `<img  src="${dataImg.data.Url}" alt="${dataImg.data.AlternativeText}" class="avatar  profile-user brround cover-image">`;
    }

    let img = $(temp);

    $("#userImgImg").append(img);
});