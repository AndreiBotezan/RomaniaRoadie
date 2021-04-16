using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RomaniaRoadie.Startup))]
namespace RomaniaRoadie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
