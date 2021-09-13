using System.Collections.Generic;

namespace Domain.Entities
{
    public class RootCauseAnalysis : Entity<int>
    {
        public int NonComplianceRegisterId { get; set; }
        public int UserId { get; set; }
        public int ActionPlainId { get; set; }
        public virtual NonComplianceRegister NonComplianceRegister { get; set; }
        public virtual User User { get; set; }
        public virtual ActionPlain ActionPlain { get; set; }
        public virtual IEnumerable<ActionPlainResponse> ActionPlainResponses { get; set; }
        public virtual IEnumerable<FiveWhat> FiveWhats { get; set; }

    }
}
