namespace Domain.Entities
{
    public class Historic : Entity<int>
    {
        public string Entity { get; set; }
        public string Values { get; set; }
    }
}
