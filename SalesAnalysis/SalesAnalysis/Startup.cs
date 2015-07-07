using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalesAnalysis.Startup))]
namespace SalesAnalysis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
