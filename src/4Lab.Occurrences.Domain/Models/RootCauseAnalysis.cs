using _4Lab.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace _4lab.Occurrences.Domain.Models
{
    public class RootCauseAnalysis : Entity<Guid>
    {
        public Guid OccurrenceRegisterId { get; set; }
        public Guid UserId { get; set; }
        public Guid ActionPlainId { get; set; }
        public virtual OccurrenceRegister OccurrenceRegister { get; set; }
        public virtual ActionPlain ActionPlain { get; set; }
        public virtual IEnumerable<ActionPlainResponse> ActionPlainResponses { get; set; }
        public virtual IEnumerable<FiveWhat> FiveWhats { get; set; }

    }
}
