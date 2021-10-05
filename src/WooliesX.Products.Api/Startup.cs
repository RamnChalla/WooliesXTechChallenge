using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;
using WooliesX.Products.Core.Queries;
using WooliesX.Products.Core.Services;
using WooliesX.Products.Data.Contexts;
using WooliesX.Products.Domain.Config;
using WooliesX.Products.Domain.Configuration;
using WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment webHostEnvironment;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The application configuration, where key value pair settings are stored.</param>
        /// <param name="webHostEnvironment">The environment the application is running under. This can be Development,Staging or Production by default.</param>
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            this.configuration = configuration;
            this.webHostEnvironment = webHostEnvironment;
            var options = Get<AppConfig>(configuration, "ApiConfig");
        }

        /// <summary>
        /// Method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();          
            services.AddCustomSwagger();
            services.AddCustomApiVersioning();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.Configure<AppConfig>(this.configuration);
            services.AddMediatR(typeof(GetUserHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetProductsHandler).GetTypeInfo().Assembly);

            var config = new AppConfig();
            services.Configure<AppConfig>(configuration.GetSection("ApiConfig"));
            services.AddSingleton<AppConfig>(config);

            // Just injecting data into our DB Context on startup
            services.AddTransient<IDbContext, ProductsDbContext>(options =>
            {
                var config = options.GetService<IOptions<AppConfig>>().Value;
                return new ProductsDbContext(new List<User>() { new User { Name = "Ram Challa", Token = config.Token } });
            });

            //Inject project services 
            services.AddTransient<IResourceService, ResourceService>();
            services.AddTransient<IOrderingService, OrderingService>();
            services.AddTransient<IPopularProductsService, PopularProductsService>();
          
            services.AddHttpClient<IResourceService, ResourceService>((serviceProvider, HttpClient) =>
                {
                    var options = serviceProvider.GetRequiredService<IOptions<AppConfig>>().Value;
                    HttpClient.BaseAddress = new Uri(options.BaseAddress);
                    HttpClient.Timeout = TimeSpan.Parse(options.Timeout);

                    HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                    HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHsts();
                app.UseSwagger();
                app.UseCustomSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(CorsPolicy.AllowAny);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        private static T Get<T>(IConfiguration config, string key) where T : new()
        {
            var instance = new T();
            config.GetSection(key).Bind(instance);
            return instance;
        }

    }
}
