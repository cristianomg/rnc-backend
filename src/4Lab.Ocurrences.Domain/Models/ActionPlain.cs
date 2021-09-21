using _4Lab.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace _4lab.Occurrences.Domain.Models
{
    public class ActionPlain : Entity<Guid>
    {
        public string Name { get; set; }
        public virtual IEnumerable<ActionPlainQuestion> Questions { get; set; }
        public virtual IEnumerable<ActionPlainResponse> Responses { get; set; }
        public virtual IEnumerable<RootCauseAnalysis> RootCauseAnalysis { get; set; }
    }
}
