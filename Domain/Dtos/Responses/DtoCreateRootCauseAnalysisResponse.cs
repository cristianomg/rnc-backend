using Domain.Dtos.Helps;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Dtos.Responses
{
    public class DtoCreateRootCauseAnalysisResponse
    {
        public int NonComplianceRegisterId { get; set; }
        public string Analyze { get; set; }
        public int UserId { get; set; }
        public int ActionPlainId { get; set; }
        public virtual IEnumerable<DtoActionPlainResponse> ActionPlainResponses { get; set; }

    }
}
