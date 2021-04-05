using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Setor : Entity<SetorType>
    {
        public string Name { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<NonComplianceRegister> NonComplianceRegisters { get; set; }
    }
}
