using Entities.IdentityUsers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Observer
{
    public class UserObserver
    {
        public async Task Notify(IEnumerable<ApplicationUser> users,UserManager<ApplicationUser> manager)
        {
            List<Task> tasks = new List<Task>();
            foreach (var user in users)
            {
               tasks.Add(user.Update(manager));
            }
            await Task.WhenAll(tasks);
        }
    }
}
