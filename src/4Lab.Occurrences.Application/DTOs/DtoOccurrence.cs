using _4Lab.Core.DomainObjects.Enums;
using System;

namespace _4lab.Occurrences.Application.DTOs
{
    public class DtoOccurrence
    {
        /// <summary>
        /// Id da não conformidade
        /// </summary>
        public Guid? Id { get; set; }
        public OccurrenceType OccurrenceTypeId { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Nome do tipo da não conformidade
        /// </summary>
        //public string DsOccurrenceType { get; set; }
    }
}
