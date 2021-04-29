using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Domain.Dtos.Responses
{
    public class DtoNonComplianceRegisterResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do usuário que realizou o registro
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Data do registro
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Hora do registro
        /// </summary>
        public string Hour { get; set; }
        /// <summary>
        /// Pessoas envolvidas
        /// </summary>
        public string PeopleInvolved { get; set; }
        /// <summary>
        /// mais informações
        /// </summary>
        public string MoreInformation { get; set; }
        /// <summary>
        /// ação imediata
        /// </summary>
        public string ImmediateAction { get; set; }
        /// <summary>
        /// Não conformidades
        /// </summary>
        public IEnumerable<DtoNonCompliance> NonCompliances { get; set; }
        /// <summary>
        /// Setor
        /// </summary>
        public string Setor { get; set; }
        /// <summary>
        /// Flag para informar se o registro de não conformidade já passou pela fase de analise de causa raiz
        /// </summary>
        public bool HasRootCauseAnalysis { get; set; }
    }
}
