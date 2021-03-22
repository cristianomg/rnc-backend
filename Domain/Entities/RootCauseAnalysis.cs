namespace Domain.Entities
{
    public class RootCauseAnalysis : Entity<int>
    {
        public int NonComplianceRegisterId { get; set; }
        public string Analyze { get; set; }
        public int UserId { get; set; }

        public virtual NonComplianceRegister NonComplianceRegister { get; set; }
        public virtual User User { get; set; }
    }
}
