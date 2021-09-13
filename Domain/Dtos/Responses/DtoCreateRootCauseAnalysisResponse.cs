using Domain.Dtos.Helps;
using Domain.Dtos.Inputs;
using System.Collections.Generic;

namespace Domain.Dtos.Responses
{
    public class DtoCreateRootCauseAnalysisResponse
    {
        public int NonComplianceRegisterId { get; set; }
        public DtoFiveWhat FiveWhat { get; set; }
        public int UserId { get; set; }
        public int ActionPlainId { get; set; }
        public virtual IEnumerable<DtoActionPlainResponse> ActionPlainResponses { get; set; }

    }
}
