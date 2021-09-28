using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Collections.Generic;

namespace _4Lab.Orchestrator.DTOs.Response
{
    public class DtoOccurrenceFacadeResponse
    {
        /// <summary>
        /// Id da não conformidade
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Link para os Anexos
        /// </summary>
        public IEnumerable<DtoArchiveFacadeResponse> Archives { get; set; }
    }
}
