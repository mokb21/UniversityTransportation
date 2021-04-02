using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityTransportation.Data;
using UniversityTransportation.Interfaces.Repository;
using UniversityTransportation.Interfaces.Services;
using UniversityTransportation.Repository;
using UniversityTransportation.Services;

namespace UniversityTransportation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Constants.ConfigurationConstants.ConnectionString));

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IStationRepository, StationRepository>();

            services.AddTransient<IStationService, StationService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UniversityTransportation.API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniversityTransportation.API v1"));
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
