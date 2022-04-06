using Entities.IdentityUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Observer
{
    public class UserObserver : IUserObserver
    {
        public IEnumerable<ApplicationUser> UsersList { get; set; }

        public void AddToUsersList(ApplicationUser user)
        {
            UsersList.Append(user);
        }
        public void Notify(IEnumerable<ApplicationUser> users)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromUsersList(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
