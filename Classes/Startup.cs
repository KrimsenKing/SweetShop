using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SweetSpotProShop.Startup))]
namespace SweetSpotProShop
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
