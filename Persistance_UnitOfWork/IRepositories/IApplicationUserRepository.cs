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
        IEnumerable<ApplicationUser> GetAllUsers();
        IEnumerable<ApplicationUser> GetAllUsersWithRoles();
        object GetAllUsersWithImagesAndRoles();
        Task<ApplicationUser> GetUser(string id);
        ApplicationUser GetUserWithPostsAndImages(string id);
        Task<ApplicationUser> GetUserWithImages(string id);
        ApplicationUser DeleteUserWithPostsAndImage(string id);
    }
}
