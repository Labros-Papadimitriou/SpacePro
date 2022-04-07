using Entities.IdentityUsers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Observer
{
    public class UserObserver : IUserObserver
    {
        public List<ApplicationUser> UsersList { get; set; }
        public UserObserver()
        {
            UsersList = new List<ApplicationUser>();
        }
        public void AddToUsersList(ApplicationUser user)
        {
            UsersList.Append(user);
        }
        public async Task Notify(IEnumerable<ApplicationUser> users,UserManager<ApplicationUser> manager)
        {
            List<Task> tasks = new List<Task>();
            UsersList.AddRange(users);
            foreach (var user in UsersList)
            {
               tasks.Add(user.Update(manager));
            }
            await Task.WhenAll(tasks);
        }

        public void RemoveFromUsersList(ApplicationUser user)
        {
            UsersList.Remove(user);
        }
    }
}
