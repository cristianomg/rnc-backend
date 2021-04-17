using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

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
            services.AddScoped<ICreateUserService, CreateUserService>();
            services.AddScoped<ICreateAuthService, CreateAuthService>();
            services.AddScoped<IRecoveryPasswordService, RecoveryPasswordService>();
            services.AddScoped<ISenderEmail, SenderEmail>();
            services.AddScoped<ICreateNonComplianceRegisterService, CreateNonComplianceRegisterService>();
            services.AddScoped<ICreateRootCauseAnalysisService, CreateRootCauseAnalysisService>();
            services.AddScoped<ISendChartToEmailService, SeendChartToEmailService>();
            services.AddScoped<IRazorViewToStringRenderer, RazorViewToStringRenderer>();
            services.AddScoped<ICreatePieChartWithNonComplianceRegisterService, CreatePieChartWithNonComplianceRegisterService>();
            services.AddScoped<IChangePasswordService, ChangePasswordService>();
            return services;
        }
    }
}
