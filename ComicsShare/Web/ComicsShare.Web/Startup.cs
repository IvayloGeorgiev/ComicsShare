using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComicsShare.Web.Startup))]
namespace ComicsShare.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
