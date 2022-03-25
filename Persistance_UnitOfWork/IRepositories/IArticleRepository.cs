using Entities.BroadClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_UnitOfWork.IRepositories
{
    public interface IArticleRepository:IRepository<Article>
    {
        IEnumerable<Article> GetArticlesWithImage();
        IEnumerable<Article> GetArticlesFullModel();
    }
}
