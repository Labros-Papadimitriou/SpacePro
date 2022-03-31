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
        Task<IEnumerable<ApplicationUser>> GetAllUsers();
        Task<IEnumerable<ApplicationUser>> GetAllUsersWithRolesAndPosts();
        Task<object> GetAllUsersWithImagesAndRoles();
        Task<ApplicationUser> GetUser(string id);
        Task<ApplicationUser> GetUserWithPostsAndImages(string id);
        Task<ApplicationUser> GetUserWithImages(string id);
        Task<ApplicationUser> DeleteUserWithPostsAndImage(string id);
    }
}
