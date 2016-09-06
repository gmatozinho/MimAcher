using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MimAcher.WebService.Startup))]
namespace MimAcher.WebService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
