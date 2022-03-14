using Entities.IdentityUsers;
using MyDatabase;
using Persistance_UnitOfWork.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_UnitOfWork.Repositories
{
    public class ApplicationUserRepository:Repository<ApplicationUser>,IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

        public ApplicationUser GetUser(string id)
        {
            var user = ApplicationDbContext.Users.Where(x=>x.Id==id)
                .FirstOrDefault();

            return user;
        }
        public ApplicationUser GetUserWithImages(string id)
        {
            var user = ApplicationDbContext.Users.Where(x => x.Id == id)
                .Include(x => x.UserImage)
                .FirstOrDefault();

            return user;
        }
        public ApplicationUser GetUserWithPostsAndImages(string id)
        {
            var user = ApplicationDbContext.Users.Where(x => x.Id == id)
                .Include(x => x.UserPosts)
                .Include(x => x.UserImage)
                .FirstOrDefault();

            return user;
        }

    }
}
