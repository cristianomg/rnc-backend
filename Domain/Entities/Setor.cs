using Domain.ValueObjects;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Setor : Entity<SetorType>
    {
        public string Name { get; set; }
        public virtual IEnumerable<User> Users { get; set; }

        public virtual User ResponsavelDoSetor { get; set; }
        public int? ResponsavelDoSetorId { get; set; }
        public virtual IEnumerable<NonComplianceRegister> NonComplianceRegisters { get; set; }
    }
}
