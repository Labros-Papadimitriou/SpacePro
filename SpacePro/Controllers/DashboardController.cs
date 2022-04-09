using Persistance_UnitOfWork;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers
{
    public class DashboardController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult> UserRoles()
        {
            var users = await _unitOfWork.ApplicationUsers.GetAllUsersWithRolesAndPosts();
            int adminsCount = 0;
            int authorsCount = 0;
            int subscribersCount = 0;
            int usersCount = 0;

            foreach (var user in users)
            {
                foreach (var role in user.Roles)
                {
                    switch (role.RoleId)
                    {
                        case "705cd783-df38-4248-925c-4f2c974ad248": adminsCount++;break;
                        case "2b9ceb6b-8a65-494c-92aa-c87e7697dd47": authorsCount++;break;
                        case "7c97b82d-97c4-4209-999f-fe114cb5ee08": subscribersCount++;break;
                        case "2698f5de-f918-4abb-8fb0-54d438f970d2": usersCount++;break;
                        default:break;
                    }
                }
            }

            dynamic model = new ExpandoObject();
            model.Admins = adminsCount;
            model.Authors = authorsCount;
            model.Subscribers = subscribersCount;
            model.Users = usersCount;

            return View(model);
        }

        public async  Task<ActionResult> ArticlesLikes()
        {
            var articles = (await _unitOfWork.Articles.GetTenBestArticles()).ToList();
            
            return View(articles);
        }

        public async Task<ActionResult> PostLikes()
        {
            var posts = (await _unitOfWork.UserPosts.GetTenBestPosts()).ToList();

            return View(posts);
        }

    }
}
