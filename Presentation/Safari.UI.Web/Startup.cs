using Microsoft.Owin;
using Owin;
using Safari.IoC.App_Start;
using WebActivatorEx;

[assembly: OwinStartupAttribute(typeof(Safari.UI.Web.Startup))]
[assembly: PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructuremapMvc), "End")]

namespace Safari.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
