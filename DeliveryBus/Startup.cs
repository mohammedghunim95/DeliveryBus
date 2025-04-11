using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeliveryBus.Startup))]
namespace DeliveryBus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
