using AdaptItAcademy.Web.services.Course;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptItAcademy.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string url = Configuration.GetValue<String>("ServiceBaseUrl");
            services.AddAuthentication("Identity.Application").AddCookie();
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddHttpClient<ITrainingService, TrainingService>(client =>
            {
                client.BaseAddress = new Uri(url);
            });

            services.AddHttpClient<IDelegateService, DelegateService>(client =>
            {
                client.BaseAddress = new Uri(url);
            });

            services.AddHttpClient<ICourseService, CourseService>(client =>
            {
                client.BaseAddress = new Uri(url);
            });

            services.AddHttpClient<IRegistrationService, RegistrationService>(client =>
            {
                client.BaseAddress = new Uri(url);
            });

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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
