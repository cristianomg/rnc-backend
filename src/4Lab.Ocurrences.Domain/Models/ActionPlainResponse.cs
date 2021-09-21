using _4Lab.Core.DomainObjects;
using System;

namespace _4lab.Occurrences.Domain.Models
{
    public class ActionPlainResponse : Entity<Guid>
    {
        public string Value { get; set; }
        public Guid ActionPlainQuestionId { get; set; }
        public Guid RootCauseAnalysisId { get; set; }
        public Guid ActionPlainId { get; set; }
        public virtual RootCauseAnalysis RootCauseAnalysis { get; set; }
        public virtual ActionPlainQuestion ActionPlainQuestion { get; set; }
        public virtual ActionPlain ActionPlain { get; set; }

    }
}