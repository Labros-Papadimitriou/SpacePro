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

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            var users = ApplicationDbContext.Users.ToList();
            return users;
        }
       public IEnumerable<ApplicationUser> GetAllUsersWithRolesAndPosts()
        {
            return ApplicationDbContext.Users.Include(x => x.Roles).Include(x=>x.UserPosts).Include(x=>x.UserImage).ToList();
        }
        public object GetAllUsersWithImagesAndRoles()
        {
            var users = ApplicationDbContext.Users
                .Select(x => new
                {
                    x.Id,
                    x.UserImage,
                    x.UserName,
                    x.DateOfBirth,
                    Role = x.Roles.FirstOrDefault()
                })
                .ToList();
                

            return users;
        }

        public async Task<ApplicationUser> GetUser(string id)
        {            
            var user =await ApplicationDbContext.Users.Where(x=>x.Id==id)
                .FirstOrDefaultAsync();

            return user;
        }
        public async Task<ApplicationUser> GetUserWithImages(string id)
        {
            var user = await ApplicationDbContext.Users.Where(x => x.Id == id)
                .Include(x => x.UserImage)
                .FirstOrDefaultAsync();

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

        public ApplicationUser DeleteUserWithPostsAndImage(string id)
        {
            var user = ApplicationDbContext.Users.Where(x => x.Id == id).Include(x => x.UserImage).FirstOrDefault();
            var UserLikes = ApplicationDbContext.PostLikes.Where(x => x.LikedUser == id).ToList();
            var ArticleLikes = ApplicationDbContext.ArticleLikes.Where(x=>x.LikedUser == id).ToList();
            int imgId;
            UserImage img;

            if (user.UserImage != null)
            {
                imgId = user.UserImage.UserImageId;
                img = ApplicationDbContext.UserImages.Find(imgId);
                ApplicationDbContext.Entry(img).State = EntityState.Deleted;
            }

            foreach (var post in user.UserPosts)
            {
                ApplicationDbContext.Entry(post).State = EntityState.Deleted;
                ApplicationDbContext.SaveChanges();
            }
            
            if (UserLikes != null)
            {
                foreach (var like in UserLikes)
                {
                    ApplicationDbContext.Entry(like).State = EntityState.Deleted;
                    ApplicationDbContext.SaveChanges();
                }
            }
            if (ArticleLikes != null)
            {
                foreach (var like in ArticleLikes)
                {
                    ApplicationDbContext.Entry(like).State = EntityState.Deleted;
                    ApplicationDbContext.SaveChanges();
                }
            }

            ApplicationDbContext.Entry(user).State = EntityState.Deleted;
            ApplicationDbContext.SaveChanges();

            return user;
        }

    }
}
