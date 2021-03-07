using Data.Rnc.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql;

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
            var connection = configuration.GetConnectionString("RncContext");
            services.AddDbContext<RncContext>(options =>
                options.UseMySql(connection));
            return services;

        }
    }
}
