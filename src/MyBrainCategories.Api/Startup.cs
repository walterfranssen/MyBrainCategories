using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBrainCategories.Application.Categories.Command.CreateCategory;
using MyBrainCategories.Application.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using MyBrainCategories.Application.Infrastructure;
using MyBrainCategories.Api.Utils;

namespace MyBrainCategories.Api
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
            services.AddMediatR(typeof(CreateCategoryCommand));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddApplication(Configuration.GetValue<string>("MongoSettings:Server"),
                Configuration.GetValue<string>("MongoSettings:Database"));

            services.AddSwaggerDocument(c => {
                c.Version = "v1";
                c.Title = "Categorie api";
            });

            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddMvcOptions(o =>
            {
                o.Filters.Add<ExceptionMapperFilterAttribute>();
            })
            .AddFluentValidation(o =>
            {
                o.RegisterValidatorsFromAssemblyContaining(typeof(RequestValidationBehavior<,>));
            }); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUi3();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseMvc();
        }
    }
}
