using System;

namespace _4lab.Occurrences.Domain.Models
{
    public class OccurrenceOccurrenceRegister
    {
        public Guid NonComplianceId { get; private set; }
        public Guid NonComplianceRegisterId { get; private set; }

        public virtual Occurrence Occurrence { get; private set; }
        public virtual OccurrenceRegister OccurrenceRegister { get; private set; }
    }
}
