using _4lab.Administration.Data;
using _4lab.Occurrences.Data;
using _4Lab.Archives.Data;
using _4Lab.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.Rnc.Extensions
{
    /// <summary>
    /// Configurações de banco de dados
    /// </summary>
    public static class DatabaseExtensions
    {
        /// <summary>
        /// Injeção dos contextos de banco de dados
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = Environment.GetEnvironmentVariable("CONNECTION") ?? configuration.GetConnectionString("OccurrencesContext");
            services.AddDbContext<OccurrencesContext>(options =>
                options.UseNpgsql(connection));
            services.AddDbContext<UserContext>(options =>
                options.UseNpgsql(connection));
            services.AddDbContext<ArchiveContext>(options =>
                options.UseNpgsql(connection));
            services.AddDbContext<CoreContext>(options =>
                options.UseNpgsql(connection));
            return services;

        }
    }
}
