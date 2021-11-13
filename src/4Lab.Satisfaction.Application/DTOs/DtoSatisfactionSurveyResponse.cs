using System;
using System.Collections.Generic;

namespace _4Lab.Satisfaction.Application.DTOs
{
    public class DtoSatisfactionSurveyResponse
    {
        public Guid Id { get; set; }
        public DtoReception Reception { get; set; }
        public DtoTecnicalArea TecnicalArea { get; private set; }
        public DtoSanitation Sanitation { get; set; }
        public DtoDeliveryResults DeliveryResults { get; set; }
        public DtoOverallIpression OverallImpression { get; set; }
        public DtoHowSatisfied HowSatisfied { get; set; }
        public List<DtoOurDifferential> OurDifferential { get; set; }
        public List<DtoWhySearch> WhySearch { get; set; }
        public DtoPersonalInformation PersonalInformations { get; set; }
    }
}
