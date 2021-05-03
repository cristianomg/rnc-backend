using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using Domain.Models.Helps;
using Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CreatePieChartWithNonComplianceRegisterService : AbstractService, ICreatePieChartWithNonComplianceRegisterService
    {
        private readonly INonComplianceRegisterRepository _nonComplianceRegisterRepository;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;
        private readonly IGeneratePDF _generatePDF;
        public CreatePieChartWithNonComplianceRegisterService(INonComplianceRegisterRepository nonComplianceRegisterRepository,
                                                              IRazorViewToStringRenderer razorViewToStringRenderer,
                                                              IGeneratePDF generatePDF)
        {
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
            _razorViewToStringRenderer = razorViewToStringRenderer;
            _generatePDF = generatePDF;
        }
        public async Task<ResponseService<byte[]>> Execute(SetorType setor, int month)
        {
            var nonComplianceGroup = await _nonComplianceRegisterRepository.GetGroupBySetor(setor, month);
            var nonComplianceGroupList = nonComplianceGroup.ToList();

            nonComplianceGroupList.ForEach(x => x.NonCompliance = RemoveEspecialCharacters(x.NonCompliance));

            var html = await _razorViewToStringRenderer.RenderViewToStringAsync("PieChart", nonComplianceGroupList);

            var chart = _generatePDF.FromHtml(html);

            return GenerateSuccessServiceResponse(chart);
        }
        private string RemoveEspecialCharacters(string word)
        {
            var map = new Dictionary<string, string>()
            {
                { "â", "a" }, { "Â", "A" }, { "à", "a" }, { "À", "A" }, {"á", "a" }, {"Á", "A" }, {"ã", "a" }, {"Ã", "A" }, {"ê", "e" }, {"Ê", "E" },
                {"è", "e" },{ "È", "E" },{"é", "e" },{"É", "E" },{"î", "i" },{"Î", "I" },{"ì", "i" },{ "Ì", "I" },{"í", "i" },{"Í", "I" },{"õ", "o" },
                {"Õ", "O"}, {"ô", "o"}, {"Ô", "O"},{ "ò", "o"}, {"Ò", "O"}, {"ó", "o"}, { "Ó", "O"}, {"ü", "u"}, { "Ü", "U"}, {"û", "u"},
                { "Û", "U" }, {"ú", "u"}, {"Ú", "U"}, {"ù", "u"}, {"Ù", "U"}, {"ç", "c" }, {"Ç", "C" }
            };
            var newWord = string.Empty;

            foreach (var c in word)
            {
                var character = map.GetValueOrDefault(c.ToString());
                if (string.IsNullOrEmpty(character))
                    character = c.ToString();
                newWord += character;
            }

            return newWord;
        }
    }
}
