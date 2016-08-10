using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDeveloper.Angular.Startup))]
namespace WebDeveloper.Angular
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
