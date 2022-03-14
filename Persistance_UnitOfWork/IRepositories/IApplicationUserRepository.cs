using Entities.IdentityUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_UnitOfWork.IRepositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetUser(string id);
        ApplicationUser GetUserWithPostsAndImages(string id);
        ApplicationUser GetUserWithImages(string id);
    }
}
