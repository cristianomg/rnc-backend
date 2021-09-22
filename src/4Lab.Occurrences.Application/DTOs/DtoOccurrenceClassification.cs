﻿using _4Lab.Core.DomainObjects.Enums;

namespace _4lab.Occurrences.Application.DTOs
{
    public class DtoOccurrenceClassification
    {
        /// <summary>
        /// Id do setor
        /// </summary>
        public OccurrenceClassificationType Id { get; set; }
        /// <summary>
        /// Nome do setor
        /// </summary>
        public string Name { get; set; }
    }
}