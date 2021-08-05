using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyFullStack.Startup))]
namespace VidlyFullStack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
