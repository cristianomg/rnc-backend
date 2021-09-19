﻿using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Collections.Generic;

namespace _4lab.Ocurrences.Application.DTOs
{
    public class DtoNonComplianceRegisterInput
    {
        /// <summary>
        /// Lista de não conformidades aplicadas ao registro
        /// </summary>
        public IEnumerable<DtoNonCompliance> NonCompliances { get; set; }
        /// <summary>
        /// Data do registro
        /// </summary>
        public DateTime RegisterDate { get; set; }
        /// <summary>
        /// Hora do registro
        /// </summary>
        public string RegisterHour { get; set; }
        /// <summary>
        /// Classificação de ocorrênce
        /// </summary>
        public OccurrenceClassificationType OccurrenceClassification { get; set; }
        /// <summary>
        /// Setor
        /// </summary>
        public SetorType Setor { get; set; }
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
        public int UserId { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string UserName { get; set; }
    }
}