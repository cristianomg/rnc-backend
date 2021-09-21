using System;
using System.Collections.Generic;

namespace _4lab.Ocurrences.Domain.Models
{
    public class NonComplianceNonComplianceRegister
    {
        public Guid NonComplianceId { get; private set; }
        public Guid NonComplianceRegisterId { get; private set; }

        public virtual NonCompliance NonCompliance { get; private set; }
        public virtual NonComplianceRegister NonComplianceRegister { get; private set; }
    }
}
