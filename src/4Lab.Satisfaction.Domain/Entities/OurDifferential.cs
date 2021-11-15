﻿using _4Lab.Core.DomainObjects;
using _4Lab.Satisfaction.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Lab.Satisfaction.Domain.Entities
{
    public class OurDifferential : Entity<Guid>
    {
        public Guid SatisfactionSurveyId { get; set; }
        public Differential Description { get; set; }
        public Differential NomeEnum { get; set; }
        public virtual SatisfactionSurvey SatisfactionSurvey { get; set; }

    }
}
