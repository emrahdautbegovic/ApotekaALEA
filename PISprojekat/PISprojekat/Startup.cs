using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PISprojekat.Startup))]
namespace PISprojekat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
