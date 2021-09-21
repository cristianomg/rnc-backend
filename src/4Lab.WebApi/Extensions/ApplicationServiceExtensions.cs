using _4lab.Administration.Application.Service;
using _4Lab.Archives.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace _4Lab.WebApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServicesInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IArchiveAppService, ArchiveAppService>();
            services.AddScoped<IArchiveAppService, ArchiveAppService>();
            return services;
        }
    }
}
