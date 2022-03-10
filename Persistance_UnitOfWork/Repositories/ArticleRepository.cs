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

        public IEnumerable<Article> GetArticlesWithImage()
        {
            return ApplicationDbContext.Articles.Include(x => x.ArticleImage);
        }
        public IEnumerable<Article> GetArticlesWithImageAndCategory()
        {
            return ApplicationDbContext.Articles.Include(x => x.ArticleCategory).Include(x => x.ArticleImage);
        }
    }
}
