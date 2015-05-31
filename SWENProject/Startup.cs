using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SWENProject.Startup))]
namespace SWENProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
