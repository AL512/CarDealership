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
using �arDealership.Application;
using �arDealership.Application.Common.Mappings;
using �arDealership.Application.Interfaces;
using �arDealership.Persistence;
using �arDealership.WebApi.Middleware;
using �arDealership.WebApi.Services;
using System.IO;
using System;

namespace �arDealership.WebApi
{
    public class Startup
    {
        /// <summary>
        /// ������������
        /// </summary>
        public IConfiguration Configuration { get; }
   
        public Startup(IConfiguration configuration) => Configuration = configuration;
        /// <summary>
        /// ��������� ��� �������, ������� ����� ��������������
        /// </summary>
        /// <param name="services">��������� ��������</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // ��������� � ������������� ����������
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(I�arDealershipDbContext).Assembly));
            });

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();

            // !!!
            // � ���� ������� ��� CORS ��� �����������!!!
            // � ������ ����� ������������!!!!
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    // ����������� ������� � ������ �����������
                    policy.AllowAnyHeader();
                    // ���������� ������� ������ ���� (GET/POST)
                    policy.AllowAnyMethod();
                    // ����������� ������� � ������ ������
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
                    //����� ������� ��������������
                    options.Authority = Configuration["Auth:Authority"];
                    options.Audience = Configuration["Auth:Audience"];
                    var RequireHttpsMetadata = false;
                    bool.TryParse(Configuration["Auth.RequireHttpsMetadata"], out RequireHttpsMetadata);
                    options.RequireHttpsMetadata = RequireHttpsMetadata;
                });

            // ��������� ��������� Swagger
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
        // ������� ����� ��������
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

            // ������ ������������ � �������� �� ����� ����������� middleware,
            // ������� ���������� �������������� �������������
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
