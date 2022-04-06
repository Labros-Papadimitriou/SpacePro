using Entities.IdentityUsers;
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
        void Notify(IEnumerable<ApplicationUser> users);
    }
}
