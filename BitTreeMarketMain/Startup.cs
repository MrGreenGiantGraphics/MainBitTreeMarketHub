using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BitTreeMarketMain.Startup))]
namespace BitTreeMarketMain
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
