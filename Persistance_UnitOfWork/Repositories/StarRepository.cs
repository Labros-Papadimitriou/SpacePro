using Entities.Bodies;
using MyDatabase;
using Persistance_UnitOfWork.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_UnitOfWork.Repositories
{
    public class StarRepository:Repository<Star>,IStarRepository
    {
        public StarRepository(ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;
    }
}
