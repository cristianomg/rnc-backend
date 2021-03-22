using Data.Rnc.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Rnc.Repositories
{
    public class RootCauseAnalysisRepository : BaseRepository<RootCauseAnalysis>, IRootCauseAnalysisRepository
    {
        public RootCauseAnalysisRepository(RncContext context) : base(context)
        {
        }
    }
}
