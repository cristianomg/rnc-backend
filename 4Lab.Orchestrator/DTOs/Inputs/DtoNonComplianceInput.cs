﻿using _4Lab.Archives.Application.DTOs;
using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Collections.Generic;

namespace _4Lab.Orchestrator.DTOs.Inputs
{
    public class DtoNonComplianceInput
    {
        /// <summary>
        /// Id da não conformidade
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// Id do tipo de não conformidade
        /// </summary>
        public NonComplianceType TypeNonComplianceId { get; set; }
        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Nome do tipo da não conformidade
        /// </summary>
        public string NameNonCompliance { get; set; }
        /// <summary>
        /// Anexos
        /// </summary>
        public List<DtoArchiveInput> Archives { get; set; }
    }
}
