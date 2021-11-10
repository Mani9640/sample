using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportsStoreMVCWenApp.Startup))]
namespace SportsStoreMVCWenApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
