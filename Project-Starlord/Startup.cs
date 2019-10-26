using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project_Starlord.Data;
using Swashbuckle.AspNetCore.Swagger;
using SwaggerOptions = Project_Starlord.Options.SwaggerOptions;

namespace Project_Starlord
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
            services.AddCors();

            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Database")));

            services.AddControllers();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //services.AddSwaggerGen(x => x.SwaggerDoc("v1", new Info
            //{
            //    Title = "Wanderer API",
            //    Version = "v1"
            //}));
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
                app.UseHsts();
            }

            app.UseStaticFiles();

            //var swaggerOptions = new SwaggerOptions();
            //Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            //app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });
            //app.UseSwaggerUI(option => { option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description); });

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
