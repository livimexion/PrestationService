using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrestationService.Startup))]
namespace PrestationService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
