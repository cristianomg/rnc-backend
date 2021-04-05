using System.Collections.Generic;

namespace Domain.Dtos.Inputs
{
    public class DtoActionPlainInput
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DtoActionPlainQuestionInput> Questions { get; set; }
    }
}
