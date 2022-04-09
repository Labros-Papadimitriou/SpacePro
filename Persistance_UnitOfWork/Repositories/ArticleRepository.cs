using Entities.BroadClasses;
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
    public class ArticleRepository:Repository<Article>,IArticleRepository
    {
        public ArticleRepository(ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

        public async Task<IEnumerable<Article>> GetArticlesWithImage()
        {
            return await ApplicationDbContext.Articles.Include(x => x.ArticleImage).ToListAsync();
        }
        public async Task<IEnumerable<Article>> GetArticlesFullModel()
        {
            return await ApplicationDbContext.Articles
                .Include(x => x.ArticleCategory)
                .Include(x => x.ArticleImage)
                .Include(x => x.ArticleLikes)
                .ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetTenBestArticles()
        {
            return await ApplicationDbContext.Articles
                .OrderByDescending(x => x.PostLikes)
                .Take(10)
                .ToListAsync();
        }
    }
}
