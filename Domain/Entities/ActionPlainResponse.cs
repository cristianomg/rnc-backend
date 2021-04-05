namespace Domain.Entities
{
    public class ActionPlainResponse : Entity<int>
    {
        public string Value { get; set; }
        public int ActionPlainQuestionId { get; set; }
        public int RootCauseAnalysisId { get; set; }
        public int ActionPlainId { get; set; }
        public virtual RootCauseAnalysis RootCauseAnalysis { get; set; }
        public virtual ActionPlainQuestion ActionPlainQuestion { get; set; }
        public virtual ActionPlain ActionPlain { get; set; }

    }
}