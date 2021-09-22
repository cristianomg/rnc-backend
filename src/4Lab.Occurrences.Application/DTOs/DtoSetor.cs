using _4Lab.Core.DomainObjects.Enums;
using System;

namespace _4lab.Occurrences.Application.DTOs
{
    public class DtoSetor
    {
        /// <summary>
        /// Id do setor
        /// </summary>
        public SetorType Id { get; set; }

        /// <summary>
        /// Nome do setor
        /// </summary>
        public string Name { get; set; }

        public Guid? SupervisorId { get; set; }

        public string UpdatedBy { get; set; }
    }
}
