﻿using System;
using INTEXII_App.Areas.Identity.Data;
using INTEXII_App.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(INTEXII_App.Areas.Identity.IdentityHostingStartup))]
namespace INTEXII_App.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false) //true if want email confirmation
                    .AddRoles<IdentityRole>()  //i have no idea how this fixed the issue, but i'll take it...
                    .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}