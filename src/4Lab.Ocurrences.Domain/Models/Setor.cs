using _4Lab.Core.DomainObjects;
using _4Lab.Core.DomainObjects.Enums;
using System.Collections.Generic;

namespace _4lab.Ocurrences.Domain.Models
{
    public class Setor : Entity<SetorType>
    {
        public string Name { get; set; }
        public int? SupervisorId { get; set; }
        public virtual IEnumerable<NonComplianceRegister> NonComplianceRegisters { get; set; }
    }
}
