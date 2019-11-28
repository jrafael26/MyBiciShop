using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBiciShop.Startup))]
namespace MyBiciShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
