using System;
using System.Collections.Generic;

namespace _4lab.Occurrences.Application.DTOs
{
    public class DtoCreateRootCauseAnalysisResponse
    {
        public DtoCreateRootCauseAnalysisResponse()
        {
            FiveWhat = new List<DtoFiveWhat>();
        }
        public Guid OccurrenceRegisterId { get; set; }
        public IEnumerable<DtoFiveWhat> FiveWhat { get; set; }
        public Guid UserId { get; set; }
        public Guid ActionPlainId { get; set; }
        public virtual IEnumerable<DtoActionPlainResponse> ActionPlainResponses { get; set; }

    }
}
