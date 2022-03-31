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
    public class PostLikeRepository : Repository<PostLike>, IPostLikeRepository
    {
        public PostLikeRepository(DbContext context) : base(context) { }
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;
        public async Task<IEnumerable<PostLike>> GetUserPostsLikes(int userPostId)
        {
            var postLikes = await ApplicationDbContext.PostLikes.Where(x => x.UserPostId == userPostId).ToListAsync();
            return postLikes;
        }
    }
}
