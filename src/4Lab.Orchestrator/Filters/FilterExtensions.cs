using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using _4Lab.Core.Enums;
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
        public static IQueryable<OccurrenceRegister> OccurrenceFilterByPending(this IQueryable<OccurrenceRegister> query, PendingFilter pendingfilter)
        {

            switch (pendingfilter)
            {
                case PendingFilter.RootCauseAnalysis:

                    query = query.Where(x => x.OccurrencePendency.Value == OccurrencePendency.RootCauseAnalysisAndActionPlan);
                    break;
                case PendingFilter.RiskAnalysis:
                    query = query.Where(x => x.OccurrencePendency.Value == OccurrencePendency.RiskRating);
                    break;
                case PendingFilter.EffectivenessPeriodicityAnalysis:
                    query = query.Where(x => x.OccurrencePendency.Value == OccurrencePendency.VerificationOfEffectiveness);
                    break;
                case PendingFilter.All:
                default:
                    break;
            }

            return query;
        }
    }
}
