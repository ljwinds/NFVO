using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NFVO.Startup))]
namespace NFVO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
