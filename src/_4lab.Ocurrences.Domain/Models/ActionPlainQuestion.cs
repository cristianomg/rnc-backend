using _4Lab.Core.DomainObjects;
using System.Collections.Generic;

namespace _4lab.Ocurrences.Domain.Models
{
    public class ActionPlainQuestion : Entity<int>
    {
        public string Value { get; set; }
        public int ActionPlainId { get; set; }
        public virtual ActionPlain ActionPlain { get; set; }
        public virtual IEnumerable<ActionPlainResponse> ActionPlainResponse { get; set; }
    }
}
