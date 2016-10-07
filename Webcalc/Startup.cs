using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Webcalc.Startup))]
namespace Webcalc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
