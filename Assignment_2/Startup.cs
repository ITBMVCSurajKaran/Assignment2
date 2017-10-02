using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment_2.Startup))]
namespace Assignment_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
