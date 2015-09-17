using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KilometroZero7.Startup))]
namespace KilometroZero7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
