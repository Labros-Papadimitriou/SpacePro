using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Entities.BroadClasses;
using SpacePro.Models.Dtos;
using Persistance_UnitOfWork;
using Entities.IdentityUsers;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Net;
using AutoMapper;

namespace SpacePro.Controllers.BroadsControllers
{
    public class ArticleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult ShowArticles()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllArticles()
        {
            var article = (await _unitOfWork.Articles
                            .GetArticlesFullModel())
                            .Select(x => new {
                                x.ArticleId,
                                x.Title,
                                x.ShortDescription,
                                x.PostDate,
                                x.PostLikes,
                                x.AuthorName,
                                Category = x.ArticleCategory.Title,
                                Url = x.ArticleImage.Url,
                                AltText = x.ArticleImage.AlternativeText
                            });

            return Json(article, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CreateArticles()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewArticle(CreateArticleDto articleDto, HttpPostedFileBase image)
        {
            if (image != null) image.SaveAs(Server.MapPath("/Content/ArticlesImages/" + image.FileName));
            if (articleDto is null) return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest,"Article wasn't in the right format");
            if (image is null) return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest, "Article Image wasn't int the right format");

            ArticleImage articleImage = new ArticleImage();
            articleImage.Name = image.FileName;
            articleImage.Url = "/Content/ArticlesImages/" + image.FileName;
            articleImage.AlternativeText = (image.FileName).Split('.')[0];
            articleDto.ArticleImage = articleImage;

            try{_unitOfWork.ArticleImages.Add(articleImage);}
            catch (Exception ex){return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest, ex.Message);}

            var article = _mapper.Map<Article>(articleDto);

            try{_unitOfWork.Articles.Add(article);}
            catch (Exception ex){return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest, ex.Message);}

            await _unitOfWork.Complete();

            return RedirectToAction("ShowArticles");
        }

        [HttpPost]
        public async Task<ActionResult> EditArticle(int? articleId, EditArticleDto editArticleDto, HttpPostedFileBase image)
        {
            if (articleId is null) { return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest); }
            var article = (await _unitOfWork.Articles.GetArticlesWithImage()).FirstOrDefault(x => x.ArticleId == articleId);

            if (image is null) {return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest, "Article Image wasn't int the right format");}

            image.SaveAs(Server.MapPath("/Content/ArticlesImages/" + image.FileName));

            ArticleImage articleImage = new ArticleImage();
            articleImage.Name = image.FileName;
            articleImage.Url = "/Content/ArticlesImages/" + image.FileName;
            articleImage.AlternativeText = (image.FileName).Split('.')[0];
            _unitOfWork.ArticleImages.Add(articleImage);
            _unitOfWork.ArticleImages.Remove(article.ArticleImage);

            editArticleDto.ArticleImage = articleImage;

            _mapper.Map(editArticleDto, article);

            _unitOfWork.Articles.ModifyEntity(article);
            await _unitOfWork.Complete();

            return RedirectToAction("ShowArticles");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteArticle(int? articleId, int? imageId)
        {
            if (articleId is null){return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);}
            var article = await _unitOfWork.Articles.Get((int)articleId);

            if (imageId is null) { return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest); }
            var articleImage = await _unitOfWork.ArticleImages.Get((int)imageId);

            var imageName = articleImage.Name;

            _unitOfWork.ArticleImages.Remove(articleImage);
            _unitOfWork.Articles.Remove(article);

            await _unitOfWork.Complete();

            DeleteImageFromFolder(imageName);

            return Json("/Article/ShowArticles",JsonRequestBehavior.AllowGet);
        }

        private void DeleteImageFromFolder(string imageName)
        {
            var filePath = Server.MapPath("/Content/ArticlesImages/" + imageName);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetArticleDetails(int? id)
        {
            if (id is null) { return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest); }

            var article = (await _unitOfWork.Articles.GetArticlesFullModel()).FirstOrDefault(x=>x.ArticleId == id);
            return View(article);
        }

        [HttpGet]
        public async Task<ActionResult> GiveLike(int? articleId)
        {
            var likedUserId = User.Identity.GetUserId();

            if (articleId is null) { return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest); }
            var article = await _unitOfWork.Articles.Get((int)articleId);

            var userNotYetLikedThisArticle = (await _unitOfWork.ArticleLikes.Find(x => x.LikedUser == likedUserId && x.ArticleId == article.ArticleId)).Count() == 0;

            if (userNotYetLikedThisArticle)
            {
                ArticleLike articleLike = new ArticleLike();
                articleLike.LikedUser = (await _unitOfWork.ApplicationUsers.Find(x => x.Id == likedUserId)).FirstOrDefault().Id;
                articleLike.ArticleId = article.ArticleId;
                _unitOfWork.ArticleLikes.Add(articleLike);
                article.ArticleLikes.Add(articleLike);
                article.PostLikes++;
                await _unitOfWork.Complete();
            }  
            return Json(article.PostLikes, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> RemoveLike(int? articleId)
        {
            var likedUserId = User.Identity.GetUserId();

            if (articleId is null) { return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest); }
            var article = await _unitOfWork.Articles.Get((int)articleId);

            var articleLike = (await _unitOfWork.ArticleLikes.Find(x => x.LikedUser == likedUserId && x.ArticleId == articleId)).FirstOrDefault();
            _unitOfWork.ArticleLikes.Remove(articleLike);
            article.PostLikes--;
            await _unitOfWork.Complete();

            return Json(article.PostLikes, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
