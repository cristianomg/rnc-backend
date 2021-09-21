using _4lab.Ocurrences.Domain.Interfaces;
using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.Data;
using System;

namespace _4lab.Ocurrences.Data.Repositories
{
    public class RootCauseAnalysisRepository : BaseRepository<RootCauseAnalysis, Guid>, IRootCauseAnalysisRepository
    {
        public RootCauseAnalysisRepository(OcurrencesContext context) : base(context)
        {
        }
    }
}
