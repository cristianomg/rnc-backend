namespace _4Lab.Satisfaction.Application.DTOs
{
    public class DtoSatisfactionSurveyInput
    {
        public DtoReception Reception { get; private set; }
        public DtoTecnicalArea TecnicalArea { get; private set; }
        public DtoSanitation Sanitation { get; private set; }
        public DtoDeliveryResults DeliveryResults { get; set; }
        public DtoOverallIpression OverallImpression { get; set; }
        public DtoHowSatisfied HowSatisfied { get; private set; }
        public DtoOurDifferential OurDifferential { get; set; }
        public DtoWhySearch WhySearch { get; set; }
        public DtoPersonalInformation PersonalInformations { get; set; }
    }
}
