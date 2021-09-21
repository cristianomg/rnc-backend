using _4Lab.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace _4lab.Occurrences.Domain.Models
{
    public class ActionPlainQuestion : Entity<Guid>
    {
        public string Value { get; set; }
        public Guid ActionPlainId { get; set; }
        public virtual ActionPlain ActionPlain { get; set; }
        public virtual IEnumerable<ActionPlainResponse> ActionPlainResponse { get; set; }
    }
}
