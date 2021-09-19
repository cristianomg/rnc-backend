﻿using _4Lab.Core.DomainObjects;
using System.Collections.Generic;

namespace _4lab.Ocurrences.Domain.Models
{
    public class NonCompliance : Entity<int>
    {
        public int TypeNonComplianceId { get; set; }
        public string Description { get; set; }
        public ICollection<NonComplianceRegister> NonComplianceRegisters { get; set; }
        public virtual TypeNonCompliance TypeNonCompliance { get; set; }
        public virtual List<Archive> Archives { get; set; } = new List<Archive>();

    }
}