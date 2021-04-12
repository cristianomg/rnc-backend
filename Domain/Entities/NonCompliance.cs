using System.Collections.Generic;

namespace Domain.Entities
{
    public class NonCompliance : Entity<int>
    {
        public int TypeNonComplianceId { get; set; }
        public string Description { get; set; }
        public virtual TypeNonCompliance TypeNonCompliance { get; set; }
        public virtual IEnumerable<NonComplianceRegister> NonCompliceRegisters  { get; set; }
    }
}
