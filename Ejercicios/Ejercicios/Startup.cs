using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ejercicios.Startup))]
namespace Ejercicios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
