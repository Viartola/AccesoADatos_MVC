using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ejercicio3.Startup))]
namespace Ejercicio3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
