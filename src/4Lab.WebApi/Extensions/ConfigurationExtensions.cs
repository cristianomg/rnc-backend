﻿using _4Lab.Core.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Api.Rnc.Extensions
{
    /// <summary>
    /// Extensões de configuração
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Registra as classes de configuração do appsettings para uso injetado com IOptions
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration">provedor de configurações</param>
        /// <returns></returns>
        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OpenApiInfo>(configuration.GetSection("ApiInfo"));
            services.Configure<CryptographConfig>(configuration.GetSection("CryptographConfig"));
            services.Configure<SendEmailConfig>(configuration.GetSection("SendEmail"));
            services.Configure<S3Config>(configuration.GetSection("S3Config"));

            services.AddHttpClient();

            return services;
        }
    }
}
