namespace _4lab.Ocurrences.Domain.Models
{
    public class NonComplianceNonComplianceRegister
    {
        public int NonComplianceId { get; set; }
        public int NonComplianceRegisterId { get; set; }

        public virtual NonCompliance NonCompliance { get; set; }
        public virtual NonComplianceRegister NonComplianceRegister { get; set; }
    }
}
