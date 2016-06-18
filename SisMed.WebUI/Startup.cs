using Microsoft.Owin;
using Owin;
using SisMed.WebUI;

[assembly: OwinStartup(typeof(Startup))]
namespace SisMed.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
