using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MimAcher.Apresentacao.Startup))]
namespace MimAcher.Apresentacao
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
