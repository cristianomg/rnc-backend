using System;
using System.Collections.Generic;

namespace _4lab.Occurrences.Application.DTOs
{
    public class DtoActionPlainDetailResponse
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DtoActionPlainQuestionResponse> Questions { get; set; }
    }
}
