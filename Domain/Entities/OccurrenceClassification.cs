using Domain.ValueObjects;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class OccurrenceClassification : Entity<OccurrenceClassificationType>
    {
        public string Name { get; set; }
        public virtual ICollection<NonComplianceRegister> NonComplianceRegisters { get; set; }
    }
}
