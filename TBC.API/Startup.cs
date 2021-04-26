using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TBC.API.Infrastructure.Midlewares;
using TBC.Application;
using TBC.Application.Services;
using TBC.Infrastructure;

namespace TBC.API
{
    /// <summary>
    /// Main Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Options>(Configuration);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TBC.API", Version = "v1" });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "TBC.API.xml");
                c.IncludeXmlComments(filePath);
            });

            services.AddInfrastructure(Configuration);
            services.AddApplication();
            services.AddAutoMapper(typeof(Startup));

            AddVersioning(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TBC.API v1"));
            }

            app.UseSwaggerUI();
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseMiddleware<RequestLocalizationMiddleware>();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddVersioning(IServiceCollection services)
        {
            services.AddVersionedApiExplorer(setupAction =>
            {
                setupAction.GroupNameFormat = "'v'VVV";
                setupAction.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ReportApiVersions = true;
            });
        }
    }
}
