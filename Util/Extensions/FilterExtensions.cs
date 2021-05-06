using Domain.Entities;
using Domain.ValueObjects;
using System.Linq;

namespace Util.Extensions
{
    public static class FilterExtensions
    {
        public static IQueryable<NonComplianceRegister> FilterByHasRootCauseAnalysis(this IQueryable<NonComplianceRegister> query, HasRootCauseAnalysisType filter)
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
