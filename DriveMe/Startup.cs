using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DriveMe.Startup))]
namespace DriveMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
