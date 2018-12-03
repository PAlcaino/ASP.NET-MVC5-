using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionToxicologica.Startup))]
namespace GestionToxicologica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
