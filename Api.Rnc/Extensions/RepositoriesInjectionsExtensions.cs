using Data.Rnc.Repositories;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Rnc.Extensions
{
    /// <summary>
    /// Classe criada para realizar a Injeção de dependencia nos repositorios.
    /// </summary>
    /// <returns></returns>
    public static class RepositoriesInjectionsExtensions
    {
        /// <summary>
        /// Realizar a Injeção de dependencia nos repositorios.
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddRepositoriesInjections(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAuthRepository, UserAuthRepository>();
            return services;
        }
    }
}
