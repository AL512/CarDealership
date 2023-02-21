using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace СarDealership.WebApi
{
    /// <summary>
    /// Настройка параметров Swagger
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        /// <summary>
        /// api провайдер
        /// </summary>
        private readonly IApiVersionDescriptionProvider _provider;

        /// <summary>
        /// Настройка параметров Swagger
        /// </summary>
        /// <param name="provider">api провайдер</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) =>
            _provider = provider;

        /// <summary>
        /// Настройка параметров Swagger
        /// </summary>
        /// <param name="options">опции Swagger'а</param>
        public void Configure(SwaggerGenOptions options)
        {
            foreach(var description in _provider.ApiVersionDescriptions)
            {
                var apiVersion = description.ApiVersion.ToString();
                options.SwaggerDoc(description.GroupName,
                    new OpenApiInfo
                    {
                        Version = apiVersion,
                        Title = $"СarDealership API {apiVersion}",
                        Description =
                            "Учебно-исследовательский проект",
                        Contact = new OpenApiContact
                        {
                            Name = "Александр",
                            Email = "В резюме",
                        },
                    });
                // для авторизации в swagger'е
                options.AddSecurityDefinition($"AuthToken {apiVersion}",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "bearer",
                        Name = "Authorization",
                        Description = "Authorization token"
                    });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = $"AuthToken {apiVersion}"
                            }
                        },
                        new string[] { }
                    }
                });

                options.CustomOperationIds(apiDescription =>
                    apiDescription.TryGetMethodInfo(out MethodInfo methodInfo)
                        ? methodInfo.Name
                        : null);
            }
        }
    }
}
