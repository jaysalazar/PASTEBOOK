using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PastebookWebApplication.Startup))]
namespace PastebookWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
