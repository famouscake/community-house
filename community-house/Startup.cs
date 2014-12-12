using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(community_house.Startup))]
namespace community_house
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
