using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WooliesX.Products.Api
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods which extend ASP.NET Core services.
    /// </summary>
    internal static class CustomServiceCollectionExtensions
    {
        /// <summary>
        /// Add custom routing settings which determines how URL's are generated.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>The services with routing services added.</returns>
        public static IServiceCollection AddCustomRouting(this IServiceCollection services) =>
            services.AddRouting(options => options.LowercaseUrls = true);

        public static IServiceCollection AddCustomApiVersioning(this IServiceCollection services) =>
            services
                .AddApiVersioning(
                    options =>
                    {
                        options.AssumeDefaultVersionWhenUnspecified = true;
                        options.ReportApiVersions = true;
                    })
                .AddVersionedApiExplorer(x => x.GroupNameFormat = "'v'VVV"); // Version format: 'v'major[.minor][-status]

        /// <summary>
        /// Adds Swagger services and configures the Swagger services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>The services with Swagger services added.</returns>
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(
                options =>
                {
                    var assembly = typeof(Startup).Assembly;
                    var assemblyProduct = assembly.GetCustomAttribute<AssemblyProductAttribute>().Product;
                  
                    options.DescribeAllParametersInCamelCase();
                    options.EnableAnnotations();

                    var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                    foreach (var apiVersionDescription in provider.ApiVersionDescriptions)
                    {
                        var info = new OpenApiInfo()
                        {
                            Version = apiVersionDescription.ApiVersion.ToString(),
                            Title = assemblyProduct,
                            Description = "WooliesX Technical Challenge Web Api"
                        };
                        options.SwaggerDoc(apiVersionDescription.GroupName, info);
                    }
                });
    }
}
