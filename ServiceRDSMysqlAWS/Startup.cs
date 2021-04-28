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
using ServiceRDSMysqlAWS.Data;
using ServiceRDSMysqlAWS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRDSMysqlAWS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            String cadena = this.Configuration.GetConnectionString("awsmysqlhospital");
            services.AddTransient<RepositoriesDepartamento>();
            services.AddDbContextPool<DepartamentoContext>(options => options.UseMySql(cadena, ServerVersion.AutoDetect(cadena)));

            services.AddCors
 (options =>
 options.AddPolicy("AllowOrigin", c => c.AllowAnyOrigin()));
            services.AddSwaggerGen(
          options =>
          {
              options.SwaggerDoc(name: "v1", new OpenApiInfo
              {
                  Title = "Api Hospital departamento AWS",
                  Version = "v1",
                  Description = "Api Hospital departamento AWS Core 2021"
              });
          });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.AllowAnyOrigin());
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(
                 options =>
                 {
                     options.SwaggerEndpoint(
                    url: "/swagger/v1/swagger.json", name: "Api v1");
                     options.RoutePrefix = "";
                 });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
