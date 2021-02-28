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
            return services;
        }
    }
}
