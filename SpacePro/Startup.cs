using Entities.IdentityUsers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MyDatabase;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpacePro.Startup))]
namespace SpacePro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
            ConfigureAuth(app);
            createRolesandUsers();
            app.MapSignalR();
        }
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            if (!roleManager.RoleExists("Admin"))
            {

                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "admin@gmail.com";

                string userPWD = "Admin123!";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                     UserManager.AddToRole(user.Id, "Admin");

                }
            }

            if (!roleManager.RoleExists("Author"))
            {
                var role = new IdentityRole();
                role.Name = "Author";
                roleManager.Create(role);

            }

            if (!roleManager.RoleExists("Subscriber"))
            {
                var role = new IdentityRole();
                role.Name = "Subscriber";
                roleManager.Create(role);

            }
        }
    }
}
