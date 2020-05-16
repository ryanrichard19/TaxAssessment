
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Core;
using Infrastructure;
using Core.Interfaces;
using Infrastructure.Data;
using MediatR;
using System.Reflection;
using Infrastructure.Handlers;

namespace BackEndAPI
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
            services.AddDbContext<ApplicationDbContext>(options =>
            { 
                options.UseSqlite("Data Source=TaxAssessment.db");
            });

            services.AddControllers();
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(NewAnnualTaxCommand).GetTypeInfo().Assembly);

            services.AddTransient<ITaxCalculatorService, TaxCalculatorService>();
            services.AddTransient<ITaxTypeService, TaxTypeService>();
            services.AddTransient<IRepository, EfRepository>();
            services.AddTransient<IAnnualTaxRepository, AnnualTaxRepository>();

            services.AddSwaggerGen(options =>
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Tax Assesment API", Version = "v1" })
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Tax Assesment API v1")
            );

            app.UseRouting();

           
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", context => {
                    context.Response.Redirect("/swagger/");
                    return Task.CompletedTask;
                });
                endpoints.MapControllers();
            });
        }
    }
}
