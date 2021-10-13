using _4lab.Occurrences.Application.DTOs;
using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Collections.Generic;

namespace _4Lab.Orchestrator.DTOs.Response
{
    public class DtoOccurrenceRegisterFacadeResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
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
        public IEnumerable<DtoOccurrenceFacadeResponse> Occurrences { get; set; }
        /// <summary>
        /// Setor
        /// </summary>
        public string Setor { get; set; }
        /// <summary>
        /// Pendência para registro de ocorrências
        /// </summary>
        public OccurrencePendency? OccurrencePendency { get; set; }
        /// <summary>
        /// Id do tipo de não conformidade
        /// </summary>
        public OccurrenceType OccurrenceTypeId { get; set; }
        /// <summary>
        /// Nome do tipo da não conformidade
        /// </summary>
        public string OccurrenceType { get; set; }

        /// <summary>
        /// Flag para verificar se o registro de ocorrencia está em atraso
        /// </summary>
        public bool IsDelayed { get; set; }
    }
}
