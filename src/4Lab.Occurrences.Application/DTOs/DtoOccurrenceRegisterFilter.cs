using _4Lab.Core.DomainObjects.Enums;
using System.Collections.Generic;

namespace _4Lab.Occurrences.Application.DTOs
{
    public class DtoOccurrenceRegisterFilter
    {
        public AnalyseFilter AnalyseFilter { get; set; } = AnalyseFilter.All;
        public List<OccurrencePendency> PendingFilter { get; set; } = new List<OccurrencePendency>();
        public bool? IsDelayed { get; set; } = null;
    }
}
