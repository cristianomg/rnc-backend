using System.Collections.Generic;

namespace _4lab.Ocurrences.Application.DTOs
{
    public class DtoActionPlainDetailResponse
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DtoActionPlainQuestionResponse> Questions { get; set; }
    }
}
