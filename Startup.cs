using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dot_net_academy_asp_mvc.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using dot_net_academy_asp_mvc.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using dot_net_academy_asp_mvc.Hubs;

namespace dot_net_academy_asp_mvc
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //services.AddSingleton<IDateTimeHelper, DateTimeHelper>();
            //services.AddSingleton<ITomorrowWrapper1, TomorrowWrapper>();

            //services.AddTransient<IDateTimeHelper, DateTimeHelper>();
            //services.AddTransient<ITomorrowWrapper1, TomorrowWrapper>();

            //services.AddScoped<IDateTimeHelper, DateTimeHelper>();
            //services.AddScoped<ITomorrowWrapper, TomorrowWrapper>();

            //services.AddSingleton<ILocationService, LocationService>();

            services.AddTransient<IRepository, Repository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<LocationsContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("LocationsContext")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseSignalR(routes =>
            {
                routes.MapHub<SignalRHub>("/signalRHub");
            });
        }
    }
}
