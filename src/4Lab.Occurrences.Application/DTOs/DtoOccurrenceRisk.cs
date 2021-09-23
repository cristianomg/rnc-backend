using _4Lab.Core.DomainObjects.Enums;

namespace _4lab.Occurrences.Application.DTOs
{
    public class DtoOccurrenceRisk
    {
        /// <summary>
        /// Id do setor
        /// </summary>
        public OccurrenceRiskType Id { get; set; }
        /// <summary>
        /// Nome do setor
        /// </summary>
        public string Name { get; set; }
    }
}
