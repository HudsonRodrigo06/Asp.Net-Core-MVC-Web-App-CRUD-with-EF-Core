using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pratice_EF_Core.Areas.Identity.Data;
using Pratice_EF_Core.Data;

[assembly: HostingStartup(typeof(Pratice_EF_Core.Areas.Identity.IdentityHostingStartup))]
namespace Pratice_EF_Core.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                
                services.AddDbContext<AuthDbContext>(options =>  
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => {
                   
                    //Retira requerimentos padroes para password e confirmação de email
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    
                })
                    .AddEntityFrameworkStores<AuthDbContext>();
            
            });
        }
    }
}