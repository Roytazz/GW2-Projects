using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using GuildWars2.Web.Data;
using GuildWars2.Web.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using GuildWars2.Web.Data.Users;
using Microsoft.AspNetCore.Http;
using GuildWars2.Manager.ValueService;
using GuildWars2.API.Providers;

namespace GuildWars2.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment()) {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets("aspnet-GuildWars2.Web-0c8b0637-c7cc-4c09-bf30-e4ee55b8e7c2");
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Cookies.ApplicationCookie.LoginPath = new PathString("/Home/Login");
                options.Cookies.ApplicationCookie.LogoutPath = new PathString("/Home/Logoff");
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy => policy.RequireRole("Administrator"));
            });
            
            services.AddMvc();

            // Add application services.
            services.AddScoped<GwUserStore>();
            services.AddScoped<GwUserManager>();
            services.AddScoped<GwSignInManager>();

            services.AddSingleton<ValueFactory>();
            services.AddSingleton<ResourceProvider>();
            services.AddSingleton<ITempDataProvider, Data.CookieTempDataProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();
            
            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
