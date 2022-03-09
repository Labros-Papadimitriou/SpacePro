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
        }

        public IStarRepository Stars { get; private set; }
        public IMoonRepository Moons { get; private set; }
        public ICometRepository Comets { get; private set; }
        public IAsteroidRepository Asteroids { get; private set; }
        public IPlanetRepository Planets { get; private set; }
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
