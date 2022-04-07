using Entities.IdentityUsers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Observer
{
    public interface IUserObserver
    {
        void AddToUsersList(ApplicationUser user);
        void RemoveFromUsersList(ApplicationUser user);
        Task Notify(IEnumerable<ApplicationUser> users,UserManager<ApplicationUser> manager);
    }
}
