using Domain.Interfaces.Util;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Cryptograph;

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
            return services;
        }
    }
}
