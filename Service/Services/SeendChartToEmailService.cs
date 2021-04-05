using CoreHtmlToImage;
using Domain.Dtos.Responses;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Helps;
using Domain.ValueObjects;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SeendChartToEmailService : AbstractService, ISendChartToEmailService
    {
        private readonly INonComplianceRegisterRepository _nonComplianceRegisterRepository;
        private readonly IEnviarEmail _enviarEmail;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;
        public SeendChartToEmailService(INonComplianceRegisterRepository nonComplianceRegisterRepository,
                                 IEnviarEmail enviarEmail,
                                 IRazorViewToStringRenderer razorViewToStringRenderer)
        {
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
            _enviarEmail = enviarEmail;
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }

        public async Task<ResponseService<string>> Execute(SetorType setor)
        {
            var nonComplianceRegisters = await _nonComplianceRegisterRepository.GetBySetor(setor);

            var group = nonComplianceRegisters.GroupBy(x => x.NonCompliance.Descricao)
                .Select(x => new DtoNonComplianceRegisterGroup
                                { NonCompliance = x.Key, Quantity = x.Count() })
                .ToList();

            try
            {
                string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Chart.cshtml", group);
                await _enviarEmail.SendEmail("cristianomg95@gmail.com", body, "Grafico", true);

                var converter = new HtmlConverter();
                var bytes = converter.FromHtmlString(body);
                File.WriteAllBytes("image.jpg", bytes);

                return GenerateSuccessServiceResponse(body);
            }
            catch(Exception ex)
            {
                return GenerateErroServiceResponse<string>(ex.Message);
            }


        }
    }
}
