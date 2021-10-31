using _4Lab.Core.DomainObjects;
using System;

namespace _4Lab.Satisfaction.Domain.Entities
{
    public class SatisfactionSurvey : Entity<Guid>
    {
        public virtual Reception Reception { get; private set; }
        public virtual TecnicalArea TecnicalArea { get; private set; }
        public virtual Sanitation Sanitation { get; private set; }
        public virtual DeliveryResults DeliveryResults { get; set; }
        public virtual OverallImpression OverallImpression { get; set; }
        public virtual HowSatisfied HowSatisfied { get; private set; }
        public virtual OurDifferential OurDifferential { get; set; }
        public virtual WhySearch WhySearch { get; set; }
        public virtual PersonalInformations PersonalInformations { get; set; }
    }
}
