using _4Lab.Core.DomainObjects;
using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Collections.Generic;

namespace _4lab.Occurrences.Domain.Models
{
    public class Occurrence : Entity<Guid>
    {
        public OccurrenceType OccurrenceTypeId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<OccurrenceRegister> OccurrenceRegisters { get; set; }
        public virtual TypeOccurrence OccurrenceType { get; set; }
    }
}
