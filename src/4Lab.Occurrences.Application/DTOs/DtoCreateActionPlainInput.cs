﻿using System.Collections.Generic;

namespace _4lab.Occurrences.Application.DTOs
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

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string UserName { get; set; }
    }
}
