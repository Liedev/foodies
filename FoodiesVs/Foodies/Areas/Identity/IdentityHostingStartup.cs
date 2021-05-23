using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Foodies.Areas.Identity.IdentityHostingStartup))]
namespace Foodies.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}