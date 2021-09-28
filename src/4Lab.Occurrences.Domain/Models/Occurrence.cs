using _4Lab.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace _4lab.Occurrences.Domain.Models
{
    public class Occurrence : Entity<Guid>
    {
        public string Description { get; set; }
        public virtual ICollection<OccurrenceRegister> OccurrenceRegisters { get; set; }
    }
}
