using System.Collections.Generic;

namespace Domain.Dtos.Inputs
{
    public class DtoActionPlainInput
    {
        /// <summary>
        /// Id do plano de ação
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Nome do plano de ação
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Perguntas do plano de ação
        /// </summary>
        public IEnumerable<DtoActionPlainQuestionInput> Questions { get; set; }
    }
}
