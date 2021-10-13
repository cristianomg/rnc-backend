using _4lab.Administration.Data.Repositories;
using _4lab.Administration.Domain.Interfaces;
using _4lab.Occurrences.Data.Repositories;
using _4lab.Occurrences.Domain.Interfaces;
using _4Lab.Archives.Data.Repositories;
using _4Lab.Archives.Domain.Interfaces;
using _4Lab.Occurrences.Data.Repositories;
using _4Lab.Occurrences.Domain.Interfaces;
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
            services.AddScoped<IOccurrenceRepository, OccurrenceRepository>();
            services.AddScoped<IOccurrenceRegisterRepository, OccurrenceRegisterRepository>();
            services.AddScoped<IRootCauseAnalysisRepository, RootCauseAnalysisRepository>();
            services.AddScoped<ISetorRepository, SetorRepository>();
            services.AddScoped<IActionPlainRepository, ActionPlainRepository>();
            services.AddScoped<IActionPlainQuestionRepository, ActionPlainQuestionRepository>();
            services.AddScoped<IOccurrenceRiskRepository, OccurrenceRiskRepository>();
            services.AddScoped<IArchiveRepository, ArchiveRepository>();
            services.AddScoped<IVerificationOfEffectivenessRepository, VerificationOfEffectivenessRepository>();
            services.AddScoped<IOccurrenceRegisterClassificationRepository, OccurrenceRegisterClassificationRepository>();
            services.AddScoped<IOccurrenceRegisterTypeRepository, OccurrenceRegisterTypeRepository>();


            return services;
        }
    }
}
