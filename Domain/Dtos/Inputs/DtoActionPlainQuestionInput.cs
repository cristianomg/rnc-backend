namespace Domain.Dtos.Inputs
{
    public class DtoActionPlainQuestionInput
    {
        public int? Id { get; set; }
        public string Value { get; set; }
        public int? ActionPlainId { get; set; }
        public DtoActionPlainResponseInput Response { get; set; }
    }
}
