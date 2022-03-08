using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpacePro.Startup))]
namespace SpacePro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
