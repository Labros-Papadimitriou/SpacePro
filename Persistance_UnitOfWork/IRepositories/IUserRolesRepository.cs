using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_UnitOfWork.IRepositories
{
    public interface IUserRolesRepository:IRepository<IdentityRole>
    {
    }
}
