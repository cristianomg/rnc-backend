﻿using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace _4Lab.Orchestrator.DTOs.Inputs
{
    public class DtoOccurrenceRegisteFacaderInput
    {
        public DtoOccurrenceRegisteFacaderInput()
        {
            Id = Guid.NewGuid();
        }
        [JsonIgnore]
        public Guid Id { get; set; }
        /// <summary>
        /// Lista de não conformidades aplicadas ao registro
        /// </summary>
        public IEnumerable<DtoOccurrenceFacadeInput> Occurrences { get; set; }
        /// <summary>
        /// Data do registro
        /// </summary>
        public DateTime RegisterDate { get; set; }
        /// <summary>
        /// Hora do registro
        /// </summary>
        public string RegisterHour { get; set; }
        /// <summary>
        /// Classificação de ocorrência
        /// </summary>
        public OccurrenceClassificationType OccurrenceClassification { get; set; }
        /// <summary>
        /// Setor
        /// </summary>
        public SetorType? Setor { get; set; }
        /// <summary>
        /// Pessoas envolvidas
        /// </summary>
        public string PeopleInvolved { get; set; }
        /// <summary>
        /// Mais informações
        /// </summary>
        public string MoreInformation { get; set; }
        /// <summary>
        /// Ação imediata
        /// </summary>
        public string ImmediateAction { get; set; }

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

        /// <summary>
        /// Id do tipo de não conformidade
        /// </summary>
        public OccurrenceType OccurrenceTypeId { get; set; }
      
    }
}
