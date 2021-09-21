using _4Lab.Core.DomainObjects;
using System;

namespace _4Lab.Core.Audit
{
    public class Historic : Entity<Guid>
    {
        public string Entity { get; set; }
        public string Values { get; set; }
    }
}
