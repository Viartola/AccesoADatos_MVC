using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ejercicio4.Startup))]
namespace Ejercicio4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
