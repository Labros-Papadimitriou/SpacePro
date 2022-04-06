$(document).ready(function () {
    $.ajax({
        url: '/Article/GetAllArticles',
        dataType: 'json',
        type: 'get',
        success: function (article) {
            console.log(article[0].AuthorName);
            for (let i = 0; i < article.length; i++) {


                let date = article[i].PostDate;
                let postdate = moment.utc(date).format('DD-MM-YYYY');

                let template = `
                                            <div class="col-sm-6 col-md-12 col-lg-6 col-xl-4">
                                                <div class="card">
                                                    <a style="border:solid 1px #0d1d40;" href="/Article/GetArticleDetails?id=${article[i].ArticleId}"><img id="article-image-${article[i].ArticleId}" class="card-img-top" src="${article[i].Url}" alt="${article[i].AlternativeText}"></a>
                                                    <div style="border:solid 1px #0d1d40; background: linear-gradient(to top, #0d1d40, black)" class="card-body d-flex flex-column">
                                                        <h3><a id="article-title-${article[i].ArticleId}" href="/Article/GetArticleDetails?id=${article[i].ArticleId}">${article[i].Title}</a></h3>
                                                        <div id="article-description-${article[i].ArticleId}" class="text-muted">${article[i].ShortDescription}</div>
                                                        <div class="d-flex align-items-center pt-5 mt-auto">
                                                            <div class="avatar brround avatar-md me-3 cover-image" data-bs-image-src="~/Template/sash/assets/images/users/18.jpg"></div>
                                                            <div>
                                                                <a href="javascript:void(0)" class="text-default">By: ${article[i].AuthorName}</a>
                                                                <small id="article-postdate-${article[i].ArticleId}" class="d-block text-muted">${"Post Date: " + postdate}</small>
                                                            </div>
                                                            <div class="media-body" style="margin-left:170px; margin-bottom:11px">
                                                                <h6 id="article-likes-${article[i].ArticleId}" class="mb-0 mt-2 ms-2">${article[i].PostLikes + " likes"}</h6>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        `;

                let column = $(template);

                $("#article-row").append(column);
            }
        }
    })
})