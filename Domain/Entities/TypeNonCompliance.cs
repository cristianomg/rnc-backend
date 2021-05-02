using System.Collections.Generic;

namespace Domain.Entities
{
    public class TypeNonCompliance : Entity<int>
    {
        public string NameNonCompliance { get; set; }
        public virtual IEnumerable<NonCompliance> NonCompliances { get; set; }
    }
}
