using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Base.WebUI.Startup))]
namespace Base.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
