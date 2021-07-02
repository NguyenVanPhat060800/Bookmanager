using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bookmanager.Startup))]
namespace Bookmanager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
