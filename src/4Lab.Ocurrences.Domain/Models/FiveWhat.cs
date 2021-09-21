using _4Lab.Core.DomainObjects;
using System;

namespace _4lab.Occurrences.Domain.Models
{
    public class FiveWhat : Entity<Guid>
    {
        public string What { get; set; }
        public Guid RootCauseAnalysisId { get; set; }
        virtual public RootCauseAnalysis RootCauseAnalysis { get; set; }
    }
}
