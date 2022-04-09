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
                        case "2c2fd5f0-347b-4bc1-9a91-fdc247dee378":adminsCount++;break;
                        case "54f378e1-3bcb-4240-99bb-8be0200c53d7": authorsCount++;break;
                        case "cebc6810-ee45-4da6-aac6-17a4a3368faf": subscribersCount++;break;
                        case "f72c1f5a-6f04-4005-b8d1-5663aa0fbdbe": usersCount++;break;
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

        public  ActionResult ArticlesLikes()
        {
            


            return View();
        }
    }
}
