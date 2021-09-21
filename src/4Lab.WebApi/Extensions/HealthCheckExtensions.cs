using _4lab.Administration.Data;
using _4lab.Occurrences.Data;
using _4Lab.Archives.Data;
using Api.Rnc.Extensions.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Rnc.Extensions
{
    public static class HealthCheckExtensions
    {
        /// <summary>
        /// Registra as verificações de saúde da api
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                    .AddDbCheck<OccurrencesContext>()
                    .AddDbCheck<UserContext>()
                    .AddDbCheck<ArchiveContext>();

            return services;
        }

        private static IHealthChecksBuilder AddDbCheck<T>(this IHealthChecksBuilder builder)
            where T : DbContext
            => builder.AddCheck<DbConnectionHealthCheck<T>>(typeof(T).Name);
    }
}
