using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using _2dv610_TDD.Models;
using _2dv610_TDD.Models.Authentication;
using _2dv610_TDD.Models.Data;
using _2dv610_TDD.Models.WishList;

namespace _2dv610_TDD
{
    public class Startup
    {
        private IConfiguration Congiguration { get; set; }
        public Startup(IConfiguration congiguration )
        {
            Congiguration = congiguration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Database Connection
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Congiguration.GetConnectionString("DefaultConnection")));

            // Ef Core Identity service
            services.AddDefaultIdentity<AuthUser>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.AddMvc();

            // Dependency Inject WishList Factory
            services.AddTransient<WishListFactory>();

            // Dependency Inject Context Service
            services.AddTransient<IAppContext, AppDbContext>();

            services.AddSession();

            // EF Cores Indentity Conditions for Password and User
            services.Configure<IdentityOptions>(options =>
            {

                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = false;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc();
            app.UseMvcWithDefaultRoute();
            app.UseCookiePolicy();
        }
    }
}
