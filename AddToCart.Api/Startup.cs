using AddToCart.Data.Repositories.Abstract;
using AddToCart.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using AddToCart.Core.Validator;

namespace AddToCart.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddBasketValidator>());

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = (docContent =>
                {
                    docContent.Info.Title = "Lolaflora Add Product To Cart Web API";
                    docContent.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "Eren Öztürk",
                        Email = "erenozzt@gmail.com"
                    };
                });
            });
            services.AddSession(o => { o.IdleTimeout = TimeSpan.FromSeconds(1800); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            app.UseSwaggerUi3();
            app.UseOpenApi();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
