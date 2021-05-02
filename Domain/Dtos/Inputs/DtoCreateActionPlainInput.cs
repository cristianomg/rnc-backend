using System.Collections.Generic;

namespace Domain.Dtos.Inputs
{
    public class DtoCreateActionPlainInput
    {
        /// <summary>
        /// Nome do plano de ação
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Perguntas do plano de ação
        /// </summary>
        public IEnumerable<DtoCreateActionPlainQuestionInput> Questions { get; set; }
    }
}
