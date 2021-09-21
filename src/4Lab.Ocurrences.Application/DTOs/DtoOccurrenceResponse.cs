using _4Lab.Core.DomainObjects.Enums;
using System;

namespace _4lab.Occurrences.Application.DTOs
{
    public class DtoOccurrenceResponse
    {
        /// <summary>
        /// Id da não conformidade
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// Id do tipo de não conformidade
        /// </summary>
        public OccurrenceType OccurrenceTypeId { get; set; }
        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Nome do tipo da não conformidade
        /// </summary>
        public string DsOccurrenceType { get; set; }
    }
}
