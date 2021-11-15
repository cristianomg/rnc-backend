using _4Lab.Core.DomainObjects;
using _4Lab.Satisfaction.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Lab.Satisfaction.Domain.Entities
{
    public class WhySearch : Entity<Guid>
    {
        public Guid SatisfactionSurveyId { get; set; }
        public Questions ResearchQuestions { get; set; }
        public Questions NomeEnum { get; set; }
        public string? Description { get; set; }
        public virtual SatisfactionSurvey SatisfactionSurvey { get; set; }
    }
}
