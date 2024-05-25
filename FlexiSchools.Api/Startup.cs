using NSwag;
using NSwag.Generation.Processors.Security;
using FlexiSchools.Infrastructure;
using Newtonsoft.Json;
using MediatR;
using Autofac;
using FlexiSchools.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using FlexiSchools.Core.Model;
using Microsoft.AspNetCore.Identity;
using FlexiSchools.Application;
using FlexiSchools.Common;

namespace FlexiSchools.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            MediatRInjections(services);
            ConfigureDatabase(services);
            ConfigureSwagger(services);
            ConfigureWebApi(services);
            MigrateAndSeedDatabase(services);
            OnInitAppConfig();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void MediatRInjections(IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("FlexiSchools.Application");
            services.AddMediatR(assembly);
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerDocument(configure: config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Demo Project";
                    document.Info.Description = "ASP.NET Core web API";
                };

                config.AddSecurity(
                    "JWT",
                    Enumerable.Empty<string>(),
                    new OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "Type into the textbox: Bearer {your JWT token}.",
                    });

                config.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
        }

        private void MigrateAndSeedDatabase(IServiceCollection services)
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            IServiceScope scope = serviceProvider.CreateScope();

            //services.SeedPearlPOSData(scope);
        }

        private void ConfigureWebApi(IServiceCollection services)
        {
            services.AddControllers();

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                });
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new RegisterApplicationContext());
            builder.RegisterModule(new RegisterHandler());
            builder.RegisterType<ApplicationContext>().As<IApplicationContext>().InstancePerDependency();
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(option =>
            {
                option.UseSqlServer(this.Configuration.GetConnectionString("dbConnection"), 
                    x =>
                    {
                        x.MaxBatchSize(1);
                        x.MigrationsHistoryTable(HistoryRepository.DefaultTableName);
                        x.MigrationsAssembly(typeof(DbContextExtensions).Assembly.GetName().Name);
                    }).UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
            });
        }

        private void OnInitAppConfig()
        {
            AppConfig.ImagePath = Configuration["ImagesPath"];
            AppConfig.CustomerImagePath = Configuration["CustomerImagePath"];
        }

    }
}
