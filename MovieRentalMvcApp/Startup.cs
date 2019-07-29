using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieRentalMvcApp.Startup))]
namespace MovieRentalMvcApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
