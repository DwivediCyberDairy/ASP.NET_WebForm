using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pramodSourceSystem.Startup))]
namespace pramodSourceSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
