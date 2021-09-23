using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace _4lab.Occurrences.Application.DTOs
{
    public class DtoRootCauseAnalysisInput
    {
        /// <summary>
        /// Id do registro de ocorrência
        /// </summary>
        public Guid OccurrenceRegisterId { get; set; }
        /// <summary>
        /// 5 Porques
        /// </summary>
        public List<DtoFiveWhat> FiveWhat { get; set; }
        /// <summary>
        /// Plano de ação
        /// </summary>
        public DtoActionPlainInput ActionPlain { get; set; }

        /// <summary>
        /// Identificador do usuário
        /// </summary>
        [JsonIgnore]
        public Guid UserId { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        [JsonIgnore]
        public string UserName { get; set; }
    }
}
