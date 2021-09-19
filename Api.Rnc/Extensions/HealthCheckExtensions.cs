using Api.Rnc.Extensions.HealthChecks;
using Data.Rnc.Context;
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
                    .AddDbCheck<OcurrencesContext>();

            return services;
        }

        private static IHealthChecksBuilder AddDbCheck<T>(this IHealthChecksBuilder builder)
            where T : DbContext
            => builder.AddCheck<DbConnectionHealthCheck<T>>(typeof(T).Name);
    }
}
