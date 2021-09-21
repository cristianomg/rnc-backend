using System;
using System.Collections.Generic;

namespace _4lab.Ocurrences.Application.DTOs
{
    public class DtoActionPlainInput
    {
        /// <summary>
        /// Id do plano de ação
        /// </summary>
        public Guid? Id { get; set; }
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
