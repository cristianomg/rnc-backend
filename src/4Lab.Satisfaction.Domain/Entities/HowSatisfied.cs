using _4Lab.Core.DomainObjects;
using _4Lab.Satisfaction.Domain.Enuns;
using System;

namespace _4Lab.Satisfaction.Domain.Entities
{
    public class HowSatisfied : Entity<Guid>
    {
        public Guid SatisfactionSurveyId { get; set; }
        public Quantitative HowSatisfiedUre { get; set; }
        public virtual SatisfactionSurvey SatisfactionSurvey { get; set; }
    }
}
