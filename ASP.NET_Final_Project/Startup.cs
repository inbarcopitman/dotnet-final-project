using ASP.NET_Final_Project.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASP.NET_Final_Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.Use(async (context, next) =>
            {
                var loggedIn = context.Session.GetInt32("LoggedIn");
                var currentPage = context.Request.Path.Value;
                var loginPath = "/login";
                var logoutPath = "/Login/Logout";
                var homePath = "/";

                if (loggedIn == null)
                {
                    if (currentPage == "/login" || currentPage == "/" || currentPage == "/login/PostLogin")
                    {
                        await next();
                        return;
                    }

                    context.Response.Redirect(loginPath);
                    return;
                }

                if (currentPage == "/login")
                {
                    context.Response.Redirect(homePath);
                    return;
                }

                var numOfActions = context.Session.GetInt32("NumOfActionAllowed");
                var newActionNum = numOfActions - 1;
                context.Session.SetInt32("NumOfActionAllowed", (int) newActionNum);
                if (newActionNum == 0)
                {
                    context.Response.Redirect(logoutPath);
                    return;
                }

                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}