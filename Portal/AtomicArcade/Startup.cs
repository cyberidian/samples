using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AtomicArcade.Startup))]
namespace AtomicArcade
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
