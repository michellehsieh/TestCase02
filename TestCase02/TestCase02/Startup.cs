using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestCase02.Startup))]
namespace TestCase02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
