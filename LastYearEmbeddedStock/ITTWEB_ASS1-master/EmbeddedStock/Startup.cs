using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmbeddedStock.Startup))]
namespace EmbeddedStock
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
