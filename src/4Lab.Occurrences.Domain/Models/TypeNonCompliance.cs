using _4Lab.Core.DomainObjects;
using _4Lab.Core.DomainObjects.Enums;
using System.Collections.Generic;

namespace _4lab.Occurrences.Domain.Models
{
    public class TypeOccurrence : Entity<OccurrenceType>
    {
        public string OccurrenceTypeName { get; set; }
        public virtual IEnumerable<OccurrenceRegister> OccurrenceRegisters { get; set; }
    }
}
