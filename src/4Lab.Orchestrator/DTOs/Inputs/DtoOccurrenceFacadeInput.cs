using System;
using System.Collections.Generic;

namespace _4Lab.Orchestrator.DTOs.Inputs
{
    public class DtoOccurrenceFacadeInput
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
        /// Anexos
        /// </summary>
        public List<DtoArchiveFacadeInput> Archives { get; set; }
    }
}
