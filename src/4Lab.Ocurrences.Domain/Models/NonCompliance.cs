using _4Lab.Core.DomainObjects;
using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Collections.Generic;

namespace _4lab.Ocurrences.Domain.Models
{
    public class NonCompliance : Entity<Guid>
    {
        public NonComplianceType TypeNonComplianceId { get; set; }
        public string Description { get; set; }
        public ICollection<NonComplianceRegister> NonComplianceRegisters { get; set; }
        public virtual TypeNonCompliance TypeNonCompliance { get; set; }
    }
}
