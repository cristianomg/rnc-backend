using Data.Rnc.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Rnc.Repositories
{
    public class RootCauseAnalysisRepository : BaseRepository<RootCauseAnalysis, int>, IRootCauseAnalysisRepository
    {
        public RootCauseAnalysisRepository(RncContext context) : base(context)
        {
        }
    }
}
