using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplicationMultiImages.Startup))]
namespace WebApplicationMultiImages
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
