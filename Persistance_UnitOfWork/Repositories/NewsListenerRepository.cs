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
    public class NewsListenerRepository : Repository<NewsListener>, INewsListenerRepository
    {
        public NewsListenerRepository(ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

        public async Task DeleteNewsListener(string id)
        {
            var listener = await ApplicationDbContext.NewsListeners.Where(x => x.UserId == id).FirstOrDefaultAsync();

            ApplicationDbContext.Entry(listener).State = EntityState.Deleted;
        }
        public bool IsTheUserListener(string id)
        {
            return ApplicationDbContext.NewsListeners.Any(x => x.UserId.Equals(id));
        }
    }
}
