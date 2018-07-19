using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SupportWheelFate.Repository;
using SupportWheelFate.BusinessLogic;
using SupportWheelFate.BusinessLogic.Interfaces;
using SupportWheelFate.Interfaces;
using SupportWheelFate.Classes;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SupportWheelFate
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
            // Options
            services.Configure<ScheduleOptions>(Configuration.GetSection("Schedule"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            //Data 
            services.AddDbContext<SupportWheelFateContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SupportWheelFateContext")));
            services.AddScoped<IEngineerRepository, EngineerRepository>();


            // Factories
            services.AddScoped<IEngineerPoolFactory, EngineerPoolFactory>();


            // services
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IScheduleStrategy, ScheduleStrategy>();
            services.AddScoped<IRuleEvaluator, RuleEvaluator>();

            // Rules for schedule generation
            services.AddTransient<IRule, ConsecutiveDayRule>();
            services.AddTransient<IRule, ShiftsPerDayRule>();
            services.AddTransient<IList<IRule>>(p => p.GetServices<IRule>().ToList());


          
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
