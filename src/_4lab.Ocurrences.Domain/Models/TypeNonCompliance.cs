using _4Lab.Core.DomainObjects;
using System.Collections.Generic;

namespace _4lab.Ocurrences.Domain.Models
{
    public class TypeNonCompliance : Entity<int>
    {
        public string NameNonCompliance { get; set; }
        public virtual IEnumerable<NonCompliance> NonCompliances { get; set; }
    }
}
