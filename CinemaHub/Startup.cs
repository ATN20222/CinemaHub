using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CinemaHub.Startup))]
namespace CinemaHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
