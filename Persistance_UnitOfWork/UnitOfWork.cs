using MyDatabase;
using Persistance_UnitOfWork.IRepositories;
using Persistance_UnitOfWork.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Stars = new StarRepository(_context);
            Moons = new MoonRepository(_context);
            Comets = new CometRepository(_context);
            Asteroids = new AsteroidRepository(_context);
            Planets = new PlanetRepository(_context);
            Articles = new ArticleRepository(_context);
            ArticleImages = new ArticleImageRepository(_context);
            ArticleCategories = new ArticleCategoryRepository(_context);
            Events = new EventRepository(_context);
            ApplicationUsers = new ApplicationUserRepository(_context);
            UserImages = new UserImageRepository(_context);
            UserPosts = new UserPostRepository(_context);
            BodyImages = new BodyImageRepository(_context);
            PostLikes = new PostLikeRepository(_context);
         }

        #region IUnitOfWork Members
        public IStarRepository Stars { get; private set; }
        public IMoonRepository Moons { get; private set; }
        public ICometRepository Comets { get; private set; }
        public IAsteroidRepository Asteroids { get; private set; }
        public IPlanetRepository Planets { get; private set; }
        public IBodyImageRepository BodyImages { get; private set; }
        public IArticleRepository Articles { get; private set; }
        public IArticleImageRepository ArticleImages { get; private set; }
        public IArticleCategoryRepository ArticleCategories { get; private set; }
        public IEventRepository Events { get; private set; }
        public IApplicationUserRepository ApplicationUsers { get; private set; }
        public IUserImageRepository UserImages { get; private set; }
        public IUserPostRepository UserPosts { get; private set; }
        public IPostLikeRepository PostLikes { get; private set; }
        #endregion

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
