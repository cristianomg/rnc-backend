namespace Domain.Entities
{
    public class Archive : Entity<int>
    {
        public string Key { get; set; }
        public int IdNonComplimance { get; set; }
        public virtual NonComplianceRegister NonComplimance { get; set; }
    }
}
