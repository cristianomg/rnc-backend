using System.Collections.Generic;

namespace Domain.Dtos.Responses
{
    public class DtoActionPlainDetailResponse
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DtoActionPlainQuestionResponse> Questions { get; set; }
    }
}
