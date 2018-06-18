using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelPatito.Startup))]
namespace HotelPatito
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
