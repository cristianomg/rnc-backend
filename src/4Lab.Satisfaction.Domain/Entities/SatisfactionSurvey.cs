using _4Lab.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace _4Lab.Satisfaction.Domain.Entities
{
    public class SatisfactionSurvey : Entity<Guid>
    {
        public Guid ReceptionId { get; set; }
        public Guid TecnicalAreaId { get; set; }
        public Guid SanitationId { get; set; }
        public Guid DeliveryResultsId { get; set; }
        public Guid OverallImpressionId { get; set; }
        public Guid HowSatisfiedId { get; set; }
        public Guid OurDifferentialId { get; set; }
        public Guid WhySearchId { get; set; }
        public Guid PersonalInformationsId { get; set; }
        public virtual Reception Reception { get; private set; }
        public virtual TecnicalArea TecnicalArea { get; private set; }
        public virtual Sanitation Sanitation { get; private set; }
        public virtual DeliveryResults DeliveryResults { get; set; }
        public virtual OverallImpression OverallImpression { get; set; }
        public virtual HowSatisfied HowSatisfied { get; private set; }
        public virtual ICollection<OurDifferential> OurDifferential { get; set; }
        public virtual ICollection<WhySearch> WhySearch { get; set; }
        public virtual PersonalInformations PersonalInformations { get; set; }
    }
}
