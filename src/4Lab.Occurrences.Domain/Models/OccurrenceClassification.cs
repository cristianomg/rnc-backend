﻿using _4Lab.Core.DomainObjects;
using _4Lab.Core.DomainObjects.Enums;
using System.Collections.Generic;

namespace _4lab.Occurrences.Domain.Models
{
    public class OccurrenceClassification : Entity<OccurrenceClassificationType>
    {
        public string Name { get; set; }
        public virtual ICollection<OccurrenceRegister> OccurrenceRegisters { get; set; }
    }
}
