using Domain.Dtos.Helps;
using _4lab.Ocurrences.Application.DTOs;
using System.Collections.Generic;

namespace _4lab.Ocurrences.Application.DTOs
{
    public class DtoCreateRootCauseAnalysisResponse
    {
        public DtoCreateRootCauseAnalysisResponse()
        {
            FiveWhat = new List<DtoFiveWhat>();
        }
        public int NonComplianceRegisterId { get; set; }
        public IEnumerable<DtoFiveWhat> FiveWhat { get; set; }
        public int UserId { get; set; }
        public int ActionPlainId { get; set; }
        public virtual IEnumerable<DtoActionPlainResponse> ActionPlainResponses { get; set; }

    }
}
