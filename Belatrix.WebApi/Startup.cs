using AutoMapper;
using Belatrix.WebApi;
using Belatrix.WebApi.Models;
using Belatrix.WebApi.Profiles;
using Belatrix.WebApi.Repository;
using Belatrix.WebApi.Repository.Postgresql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

[assembly: ApiConventionType(typeof(BelatrixApiConventions))]
namespace Belatrix.WebApi
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
            Mapper.Initialize(conf =>
            {
                conf.AddProfile<CustomersProfile>();
            });

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddEntityFrameworkNpgsql()
                        .AddDbContext<BelatrixDbContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("postgresql"), b => b.MigrationsAssembly("Belatrix.WebApi")))
                                .BuildServiceProvider();

            services.AddTransient<IRepository<Customer>, Repository<Customer>>();

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Belatrix Api",
                    Version = "v1"
                });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Belatrix Api v1");
            });
        }
    }
}
