using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(theSweetSpotDiscountGolf.Startup))]
namespace theSweetSpotDiscountGolf
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
