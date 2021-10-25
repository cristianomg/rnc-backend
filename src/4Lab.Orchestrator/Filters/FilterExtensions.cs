using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using _4Lab.Core.Enums;
using _4Lab.Orchestrator.DTOs.Response;
using System.Collections.Generic;
using System.Linq;

namespace _4Lab.Orchestrator.Filters
{
    public static class FilterExtensions
    {
        public static IQueryable<OccurrenceRegister> OccurenceFilterByAnalyse(this IQueryable<OccurrenceRegister> query, AnalyseFilter filter)
        {

            switch (filter)
            {
                case AnalyseFilter.NotFinished:
                    query = query.Where(x => x.OccurrencePendency.HasValue);
                    break;
                case AnalyseFilter.Finished:
                    query = query.Where(x => !x.OccurrencePendency.HasValue);
                    break;
                case AnalyseFilter.All:
                default:
                    break;
            }

            return query;
        }
        public static IQueryable<OccurrenceRegister> OccurrenceFilterByPending(this IQueryable<OccurrenceRegister> query, List<OccurrencePendency> pendingfilter)
        {

            if (pendingfilter != null && pendingfilter.Any())
            {
                query = query.Where(x => pendingfilter.Contains(x.OccurrencePendency.Value));
            }

            return query;
        }
        public static IQueryable<DtoOccurrenceRegisterFacadeResponse> OccurrenceFilterByPendingDelayed(this IQueryable<DtoOccurrenceRegisterFacadeResponse> query, bool? delayedFilter)
        {

            if (delayedFilter.HasValue)
            {
                query = query.ToList().Where(x => x.IsDelayed == delayedFilter.Value).AsQueryable();
            }

            return query;
        }
    }
}
