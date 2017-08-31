using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Entity_Framework_test.Startup))]
namespace Entity_Framework_test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
