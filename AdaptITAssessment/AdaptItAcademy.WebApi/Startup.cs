using AdaptItAcademy.BusinessLogic.DataLogic;
using AdaptItAcademy.BusinessLogic.Utilities;
using AdaptItAcademy.DataAccess.Models;
using AdaptItAcademy.DataAccess.Services.courses;
using AdaptItAcademy.DataAccess.Services.delegates;
using AdaptItAcademy.DataAccess.Services.GenericRepository;
using AdaptItAcademy.DataAccess.Services.registration;
using AdaptItAcademy.DataAccess.Services.trainings;
using AdaptItAcademy.DataAccess.Services.traningCost;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptItAcademy.WebApi
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
            services.AddDbContext<AdaptItAcademyContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IDelegateRepository, DelegateRepository>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<IRegistrationRepository, RegistrationRepository>();
            services.AddScoped<ITrainingCostRepository, TrainingCostRepository>();
            services.AddScoped<IDelegateLogic, DelegateLogic>();
            services.AddScoped<ICourseLogic, CourseLogic>();
            services.AddScoped<ITrainingLogic, TrainingLogic>();
            services.AddScoped<ITrainingRegistrationLogic, TrainingRegistrationLogic>();
            services.AddControllers().AddNewtonsoftJson(x =>
            x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
