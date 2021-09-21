using _4lab.Infrastructure.Smtp;
using _4lab.Infrastructure.Storage;
using Amazon;
using Amazon.S3;
using Microsoft.Extensions.Configuration;
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
        public static IServiceCollection AddServicesInjections(this IServiceCollection services, IConfiguration configuration)
        {

            var ACCESS_KEY_ID = configuration.GetValue<string>("S3Config:AccessKeyId");
            var ACCESS_KEY = configuration.GetValue<string>("S3Config:AccessKey");

            services.AddSingleton<IAmazonS3>(new AmazonS3Client(ACCESS_KEY_ID, ACCESS_KEY, RegionEndpoint.USEast1));
            services.AddScoped<IStorageService, S3StorageService>();
            services.AddScoped<IEmailSender, SenderEmail>();
            return services;
        }
    }
}
