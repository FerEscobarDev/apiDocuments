﻿using apiDocuments.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace apiDocuments
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //constructor
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; } //Define propiedad configuration

        public void ConfigureServices(IServiceCollection services) //Se configuran los servicios
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IFileStorage, LocalFileStorage>();
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(Configuration.GetConnectionString("MySqlConnection"), new MySqlServerVersion(new Version(8, 0, 30))));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles(); //Para permitir ver los archivos en local

            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
