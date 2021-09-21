using _4Lab.Core.DomainObjects;
using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Collections.Generic;

namespace _4lab.Occurrences.Domain.Models
{
    public class Setor : Entity<SetorType>
    {
        public string Name { get; set; }
        public Guid? SupervisorId { get; set; }
        public virtual IEnumerable<OccurrenceRegister> NonComplianceRegisters { get; set; }
    }
}
