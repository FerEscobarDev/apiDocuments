using Microsoft.AspNetCore.Builder;

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
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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
