using Microsoft.Extensions.DependencyInjection;

namespace Api.Rnc.Extensions
{
    /// <summary>
    /// Classe criada para realizar a Injeção de dependencia nos services.
    /// </summary>
    /// <returns></returns>
    public static class ServicesInjectionsExtensions
    {
        /// <summary>
        /// Realizar a Injeção de dependencia nos services.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServicesInjections(this IServiceCollection services)
        {
            return services;
        }
    }
}
