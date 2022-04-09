using Entities.IdentityUsers;
using MyDatabase;
using Persistance_UnitOfWork.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Persistance_UnitOfWork.Repositories
{
    public class UserPostRepository : Repository<UserPost>, IUserPostRepository
    {
        public UserPostRepository(ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

        public async Task<IEnumerable<UserPost>> GetPostWithLikes()
        {

            var userPost = await ApplicationDbContext.UserPosts.Include(x => x.PostLikes).ToListAsync();

            return userPost;
        }

        public async Task<IEnumerable<UserPost>> GetTenBestPosts()
        {
            return await ApplicationDbContext.UserPosts
                .OrderByDescending(x => x.PostLikes)
                .Take(10)
                .ToListAsync();
        }
    }
}
