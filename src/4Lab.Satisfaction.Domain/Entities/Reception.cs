using _4Lab.Core.DomainObjects;
using _4Lab.Satisfaction.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Lab.Satisfaction.Domain.Entities
{
    public class Reception : Entity<Guid>
    {
        public Guid SatisfactionSurveyId { get; set; }
        public Quantitative WaitingTime { get; set; }
        public Quantitative AttendanceAgility { get; set; }
        public Quantitative NomeEnum { get; set; }
        public virtual SatisfactionSurvey SatisfactionSurvey { get; set; }
    }
}
