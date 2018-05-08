using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HR_ASP_Project.Startup))]
namespace HR_ASP_Project
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
