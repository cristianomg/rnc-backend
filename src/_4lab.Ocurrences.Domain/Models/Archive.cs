using _4Lab.Core.DomainObjects;

namespace _4lab.Ocurrences.Domain.Models
{
    public class Archive : Entity<int>
    {
        public int NonComplianceId { get; set; }
        public int NonComplianceRegisterId { get; set; }
        public string Key { get; set; }
        public virtual NonComplianceRegister NonComplianceRegister { get; set; }
        public virtual NonCompliance NonCompliance { get; set; }
    }
}
