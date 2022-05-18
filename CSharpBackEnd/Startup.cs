using CSharpBackEnd.Data;
using CSharpBackEnd.Middleware;
using CSharpBackEnd.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;


namespace CSharpBackEnd
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ParcerContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddControllers();
             services.AddCors(options =>
             {
                 options.AddPolicy("AllowlhVue", policy =>
                 {
                 
                 policy.WithOrigins("http://localhost:8081")
                     .AllowAnyHeader()
                     .AllowAnyMethod()
                     .WithExposedHeaders("X-Total-Count");
                     policy.WithOrigins("http://localhost:8080")
                     .AllowAnyHeader()
                     .AllowAnyMethod()
                     .WithExposedHeaders("X-Total-Count");
                 });
             });
            services.AddScoped<IParcerXmlService, ParcerXmlService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("AllowlhVue");

            //app.UseApiVersioning();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
