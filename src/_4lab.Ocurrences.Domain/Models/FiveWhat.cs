using _4Lab.Core.DomainObjects;

namespace _4lab.Ocurrences.Domain.Models
{
    public class FiveWhat : Entity<int>
    {
        public string What { get; set; }
        public int RootCauseAnalysisId { get; set; }
        virtual public RootCauseAnalysis RootCauseAnalysis { get; set; }
    }
}
