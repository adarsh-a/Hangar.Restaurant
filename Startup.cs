using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hangar.Restaurant.Startup))]
namespace Hangar.Restaurant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
