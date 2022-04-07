using Entities.Observer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IdentityUsers
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            UserPosts = new HashSet<UserPost>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AboutMe { get; set; }

        public string Work { get; set; }

        public string Education { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool IsAuthorOfTheMonth { get; set; }

        public bool IsWinnerSub { get; set; }

        public ICollection<UserPost> UserPosts { get; set; }

        public UserImage UserImage { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            await manager.AddToRoleAsync(userIdentity.GetUserId(), "User");
            return userIdentity;
        }
       public async Task Update(UserManager<ApplicationUser> manager)
        {
            if (IsWinnerSub)
            {
               await manager.AddToRoleAsync(this.Id, "Subscriber");
                await manager.RemoveFromRoleAsync(Id, "User");
            }
        }
    }
}
