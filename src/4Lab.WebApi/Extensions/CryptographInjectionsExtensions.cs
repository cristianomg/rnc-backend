using _4lab.Infrastructure.Authorization;
using _4Lab.Infrastructure.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Rnc.Extensions
{
    /// <summary>
    /// Classe responsável por injetar a criptografia
    /// </summary>
    public static class CryptographInjectionsExtensions
    {
        /// <summary>
        /// Realizar a Injeção de dependencia da criptografia.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCryptographInjection(this IServiceCollection services)
        {
            services.AddScoped<ICryptograph, SHA256Cryptograph>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
