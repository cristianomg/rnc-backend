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
        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; set; }
        public bool IsExisting { get; set; }
    }
}
