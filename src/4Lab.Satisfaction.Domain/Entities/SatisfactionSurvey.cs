namespace _4Lab.Satisfaction.Domain.Entities
{
    public class SatisfactionSurvey
    {
        public Reception Reception { get; private set; }
        public TecnicalArea TecnicalArea { get; private set; }
        public Sanitation Sanitation { get; private set; }
        public DeliveryResults DeliveryResults { get; set; }
        public OverallImpression OverallImpression { get; set; }
        public HowSatisfied HowSatisfied { get; private set; }
        public string ComplimentsSuggestionsAndComplaints { get; private set; }
    }
    public class HowSatisfied
    {

    }
}
