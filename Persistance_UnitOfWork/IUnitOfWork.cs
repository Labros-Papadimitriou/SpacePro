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
        int Complete();
    }
}
