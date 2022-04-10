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

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            var users = await ApplicationDbContext.Users.ToListAsync();
            return users;
        }
       public async Task<IEnumerable<ApplicationUser>> GetAllUsersWithRolesAndPosts()
        {
            return await ApplicationDbContext.Users.Include(x => x.Roles).Include(x=>x.UserPosts).Include(x=>x.UserImage).ToListAsync();
        }
        public async Task<object> GetAllUsersWithImagesAndRoles()
        {
            var users = await ApplicationDbContext.Users
                .Select(x => new
                {
                    x.Id,
                    x.UserImage,
                    x.UserName,
                    x.DateOfBirth,
                    Role = x.Roles.FirstOrDefault()
                })
                .ToListAsync();
                

            return users;
        }

        public async Task<ApplicationUser> GetUser(string id)
        {            
            var user =await ApplicationDbContext.Users.Where(x=>x.Id==id)
                .FirstOrDefaultAsync();

            return user;
        }
        public async Task<string> GetUserName(string id)
        {
            var userName = (await ApplicationDbContext.Users.Where(x => x.Id == id)
                .FirstOrDefaultAsync()).UserName;

            return userName;
        }
        public async Task<ApplicationUser> GetUserWithImages(string id)
        {
            var user = await ApplicationDbContext.Users.Where(x => x.Id == id)
                .Include(x => x.UserImage)
                .FirstOrDefaultAsync();

            return user;
        }
        public async Task<ApplicationUser> GetUserWithPostsAndImages(string id)
        {
            var user = await ApplicationDbContext.Users.Where(x => x.Id == id)
                .Include(x => x.UserPosts)
                .Include(x => x.UserImage)
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<ApplicationUser> DeleteUserWithPostsAndImage(string id)
        {
            var user = await ApplicationDbContext.Users.Where(x => x.Id == id).Include(x => x.UserImage).FirstOrDefaultAsync();
            var UserLikes = await ApplicationDbContext.PostLikes.Where(x => x.LikedUser == id).ToListAsync();
            var ArticleLikes = await ApplicationDbContext.ArticleLikes.Where(x=>x.LikedUser == id).ToListAsync();
            int imgId;
            UserImage img;

            if (user.UserImage != null)
            {
                imgId = user.UserImage.UserImageId;
                img = await ApplicationDbContext.UserImages.FindAsync(imgId);
                ApplicationDbContext.Entry(img).State = EntityState.Deleted;
            }

            foreach (var post in user.UserPosts)
            {
                ApplicationDbContext.Entry(post).State = EntityState.Deleted;
            }
            
            if (UserLikes != null)
            {
                foreach (var like in UserLikes)
                {
                    ApplicationDbContext.Entry(like).State = EntityState.Deleted;
                }
            }
            if (ArticleLikes != null)
            {
                foreach (var like in ArticleLikes)
                {
                    ApplicationDbContext.Entry(like).State = EntityState.Deleted;
                }
            }

            ApplicationDbContext.Entry(user).State = EntityState.Deleted;

            return user;
        }

    }
}
