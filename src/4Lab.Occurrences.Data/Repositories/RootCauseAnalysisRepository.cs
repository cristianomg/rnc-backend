using _4lab.Occurrences.Domain.Interfaces;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using System;

namespace _4lab.Occurrences.Data.Repositories
{
    public class RootCauseAnalysisRepository : BaseRepository<RootCauseAnalysis, Guid>, IRootCauseAnalysisRepository
    {
        public RootCauseAnalysisRepository(OccurrencesContext context) : base(context)
        {
        }
    }
}
