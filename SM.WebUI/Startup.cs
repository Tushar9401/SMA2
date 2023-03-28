using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SM.WebUI.Startup))]
namespace SM.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
