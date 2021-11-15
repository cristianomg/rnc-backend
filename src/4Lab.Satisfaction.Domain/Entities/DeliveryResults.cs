using _4Lab.Core.DomainObjects;
using _4Lab.Satisfaction.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Lab.Satisfaction.Domain.Entities
{
    public class DeliveryResults : Entity<Guid>
    {
        public Guid SatisfactionSurveyId { get; set; }
        public Quantitative DeliveryPunctuality { get; set; }
        public Quantitative DeliveryResultTime { get; set; }
        public Quantitative NomeEnum { get; set; }
        public virtual SatisfactionSurvey SatisfactionSurvey { get; set; }
    }
}
