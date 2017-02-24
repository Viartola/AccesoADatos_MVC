using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PCBOX.Startup))]
namespace PCBOX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
