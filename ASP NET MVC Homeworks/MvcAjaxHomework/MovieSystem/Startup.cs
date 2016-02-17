using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieSystem.Startup))]
namespace MovieSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
