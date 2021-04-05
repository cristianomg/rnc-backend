using System.Collections.Generic;

namespace Domain.Entities
{
    public class ActionPlainQuestion : Entity<int>
    {
        public string Value { get; set; }
        public int ActionPlainId { get; set; }
        public virtual ActionPlain ActionPlain { get; set; }
        public virtual IEnumerable<ActionPlainResponse> ActionPlainResponse { get; set; }
    }
}
