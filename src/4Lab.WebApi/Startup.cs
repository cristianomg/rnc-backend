using _4lab.Administration.Application.Mapper;
using _4lab.Administration.Data;
using _4lab.Occurrences.Application.Mapper;
using _4lab.Occurrences.Data;
using _4Lab.Archives.Application.Mapper;
using _4Lab.Archives.Data;
using _4Lab.Core.Data;
using _4Lab.Orchestrator.Mapper;
using _4Lab.Satisfaction.Application.Mapper;
using _4Lab.Satisfaction.Data;
using _4Lab.WebApi.Extensions;
using Api.Rnc.Extensions;
using Data.Rnc.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.Rnc
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
            services.AddControllers()
                    .AddCustomJsonOptions();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            var JWT_SECRET_KEY = Configuration.GetValue<string>("CryptographConfig:JwtSecretKey");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(x =>
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWT_SECRET_KEY)),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });

            services.AddCors(x =>
                x.AddPolicy("Cors", builder => builder
                                                        .AllowAnyHeader()
                                                        .AllowAnyMethod()
                                                        .AllowAnyOrigin()));

            services.AddDbContexts(Configuration)
                    .AddCustomSwaggerGen()
                    .AddCustomConfiguration(Configuration)
                    .AddRepositoriesInjections()
                    .AddServicesInjections(Configuration)
                    .AddCustomHealthChecks()
                    .AddRepositoriesInjections()
                    .AddCryptographInjection()
                    .AddApplicationServicesInjection()
                    .AddAutoMapper(typeof(UserMapper), typeof(OccurrencesMapper), typeof(ArchiveMapper), typeof(OrchestratorMapper), typeof(SatisfactionMapper));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var coreContext = serviceScope.ServiceProvider.GetRequiredService<CoreContext>();

                coreContext.Database
                    .Migrate();

                var occurrencesContext = serviceScope.ServiceProvider.GetRequiredService<OccurrencesContext>();

                occurrencesContext.Database
                    .Migrate();

                new SeedInitial(occurrencesContext)
                    .Init();

                var usersContext = serviceScope.ServiceProvider.GetRequiredService<UserContext>();

                usersContext.Database
                    .Migrate();

                var archiveContext = serviceScope.ServiceProvider.GetRequiredService<ArchiveContext>();

                archiveContext.Database
                    .Migrate();

                var satisfactionContext = serviceScope.ServiceProvider.GetRequiredService<SatisfactionContext>();

                satisfactionContext.Database
                    .Migrate();

            }

            if (env.IsProduction())
            {
                app.UseExceptionHandler("/error");
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample Api V1");
                c.RoutePrefix = string.Empty;  // Set Swagger UI at apps root
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Cors");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
