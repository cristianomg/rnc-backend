namespace Domain.Entities
{
    public class Archives : Entity<int>
    {
        public int IdArchive { get; set; }
        public int IdNonComplimance { get; set; }
        public virtual NonComplianceRegister NonComplimance { get; set; }
    }
}
