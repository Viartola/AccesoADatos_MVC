using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ejercicios2.Startup))]
namespace Ejercicios2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
