using Amazon;
using Amazon.S3;
using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using Util.AmazonS3;
using Util.GeneratePDF;
using Util.RenderRazorPage;

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

            services.AddScoped<ICreateUserService, CreateUserService>();
            services.AddScoped<ICreateAuthService, CreateAuthService>();
            services.AddScoped<IRecoveryPasswordService, RecoveryPasswordService>();
            services.AddScoped<IEmailSender, SenderEmail>();
            services.AddScoped<ICreateNonComplianceRegisterService, CreateNonComplianceRegisterService>();
            services.AddScoped<ICreateRootCauseAnalysisService, CreateRootCauseAnalysisService>();
            services.AddScoped<ISendChartToEmailService, SeendChartToEmailService>();
            services.AddScoped<IRazorViewToStringRenderer, RazorViewToStringRenderer>();
            services.AddScoped<ICreatePieChartWithNonComplianceRegisterService, CreatePieChartWithNonComplianceRegisterService>();
            services.AddScoped<IChangePasswordService, ChangePasswordService>();
            services.AddScoped<ICreateActionPlainService, CreateActionPlainService>();
            services.AddScoped<IChangeNameService, ChangeNameSerivce>();
            services.AddScoped<ICreateNonComplianceRegisterReportService, CreateNonComplianceRegisterReportService>();
            services.AddScoped<ISendNonComplianceRegisterReportToEmailService, SendNonComplianceRegisterReportToEmailService>();
            services.AddScoped<IGeneratePDF, GeneratePDF>();
            services.AddScoped<ISetSupervisorOnSetorService, SetSupervisorOnSetorService>();
            services.AddScoped<IEvalUserSendEmail, EvalUserSendEmail>();
            services.AddScoped<IGetNonComplieanceRegisterByIdService, GetNonComplieanceRegisterByIdService>();
            services.AddSingleton<IAmazonS3>(new AmazonS3Client(ACCESS_KEY_ID, ACCESS_KEY, RegionEndpoint.USEast1));
            services.AddScoped<IStorageService, S3StorageService>();
            return services;
        }
    }
}
