using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerGen;
using СarDealership.Application;
using СarDealership.Application.Common.Mappings;
using СarDealership.Application.Interfaces;
using СarDealership.Persistence;
using СarDealership.WebApi.Middleware;
using СarDealership.WebApi.Services;
using System.IO;
using System;

namespace СarDealership.WebApi
{
    public class Startup
    {
        /// <summary>
        /// Конфигурация
        /// </summary>
        public IConfiguration Configuration { get; }
   
        public Startup(IConfiguration configuration) => Configuration = configuration;
        /// <summary>
        /// Добавляет все сервисы, которые будут использоваться
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Добавляем и конфигурируем автомаппер
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IСarDealershipDbContext).Assembly));
            });

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();

            // !!!
            // В демо правила для CORS без ограничений!!!
            // В релизе нужно ограничивать!!!!
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    // принимаются запросы с любыми заголовками
                    policy.AllowAnyHeader();
                    // ринимаются запросы любого типа (GET/POST)
                    policy.AllowAnyMethod();
                    // принимаются запросы с любого адреса
                    policy.AllowAnyOrigin();
                });
            });

            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(Configuration["Auth:AuthenticationScheme"], options =>
                {
                    //Адрес сервера аутентификации
                    options.Authority = Configuration["Auth:Authority"];
                    options.Audience = Configuration["Auth:Audience"];
                    var RequireHttpsMetadata = false;
                    bool.TryParse(Configuration["Auth.RequireHttpsMetadata"], out RequireHttpsMetadata);
                    options.RequireHttpsMetadata = RequireHttpsMetadata;
                });

            // Добавляем генератор Swagger
            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            //services.AddSwaggerGen();
            services.AddSwaggerGen(config =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });
            services.AddApiVersioning();

            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Порядок имеет значение
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    config.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                    config.RoutePrefix = string.Empty;
                }
            });
            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            // должен встраиваться в конвейер до любых компонентов middleware,
            // которые используют аутентификацию пользователей
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseApiVersioning();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
