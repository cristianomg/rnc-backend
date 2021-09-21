using _4Lab.Core.DomainObjects.Enums;
using System.Collections.Generic;

namespace _4lab.Ocurrences.Application.DTOs
{
    public class DtoNonComplianceResponse
    {
        /// <summary>
        /// Id da não conformidade
        /// </summary>
        public int? Id { get; set; }
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
        /// Link para os Anexos
        /// </summary>
        public List<string> Archives { get; set; } = new List<string>();
    }
}
