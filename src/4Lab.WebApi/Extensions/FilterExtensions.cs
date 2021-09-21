using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using System.Linq;

namespace _4Lab.WebApi.Extensions
{
    public static class FilterExtensions
    {
        public static IQueryable<OccurrenceRegister> FilterByHasRootCauseAnalysis(this IQueryable<OccurrenceRegister> query, HasRootCauseAnalysisType filter)
        {

            switch (filter)
            {
                case HasRootCauseAnalysisType.NotHave:
                    query = query.Where(x => x.RootCauseAnalysis == null);
                    break;
                case HasRootCauseAnalysisType.Have:
                    query = query.Where(x => x.RootCauseAnalysis != null);
                    break;
                case HasRootCauseAnalysisType.All:
                default:
                    break;
            }

            return query;
        }
    }
}
