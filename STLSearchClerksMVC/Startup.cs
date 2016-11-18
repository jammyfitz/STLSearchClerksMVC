using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(STLSearchClerksMVC.Startup))]
namespace STLSearchClerksMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
