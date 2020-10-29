using System;
using HealthForYou.Areas.Identity.Data;
using HealthForYou.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(HealthForYou.Areas.Identity.IdentityHostingStartup))]
namespace HealthForYou.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<HealthForYouContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("HealthForYouContextConnection")));

                services.AddDefaultIdentity<HealthForYouUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<HealthForYouContext>();
            });
        }
    }
}