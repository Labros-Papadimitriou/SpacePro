using Persistance_UnitOfWork.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IStarRepository Stars { get; }
        ICometRepository Comets { get; }
        IPlanetRepository Planets { get; }
        IAsteroidRepository Asteroids { get; }
        IMoonRepository Moons { get; }
        IBodyImageRepository BodyImages { get; }
        IEventRepository Events { get; }
        IArticleCategoryRepository ArticleCategories { get; }
        IArticleImageRepository ArticleImages { get; }
        IArticleRepository Articles { get; }
        IArticleLikeRepository ArticleLikes { get; }   
        IApplicationUserRepository ApplicationUsers { get; }
        IUserImageRepository UserImages { get; }
        IUserPostRepository UserPosts { get; }
        IPostLikeRepository PostLikes { get; }
        IUserRolesRepository UserRoles { get; }
        IChatMessageRepository ChatMessages { get; }
        int Complete();
    }
}
