using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ejercicio5.Startup))]
namespace Ejercicio5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
