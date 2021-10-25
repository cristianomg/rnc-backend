using _4lab.Administration.Application.Service;
using _4lab.Occurrences.Application.Service;
using _4Lab.Archives.Application.Service;
using _4Lab.Orchestrator.Facades;
using _4Lab.Orchestrator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace _4Lab.WebApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServicesInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IArchiveAppService, ArchiveAppService>();
            services.AddScoped<IOccurrenceAppService, OccurrenceAppService>();
            services.AddScoped<ISetorAppService, SetorAppService>();

            services.AddScoped<ICreateOccurrenceRegisterFacade, CreateOccurrenceRegisterFacade>();
            services.AddScoped<IGetOccurrenceRegisterByIdFacade, GetOccurrenceRegisterByIdFacade>();
            services.AddScoped<IGetOccurrenceRegisterAll, GetOccurrenceRegisterAll>();
            

            return services;
        }
    }
}
