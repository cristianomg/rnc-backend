using _4Lab.Core.DomainObjects;

namespace _4Lab.Core.Audit
{
    public class Historic : Entity<int>
    {
        public string Entity { get; set; }
        public string Values { get; set; }
    }
}
