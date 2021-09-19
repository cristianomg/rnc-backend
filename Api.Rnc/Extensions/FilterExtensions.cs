using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using System.Linq;

namespace _4Lab.WebApi.Extensions
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
