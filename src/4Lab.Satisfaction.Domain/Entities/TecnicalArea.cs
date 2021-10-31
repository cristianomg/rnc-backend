﻿using _4Lab.Core.DomainObjects;
using _4Lab.Satisfaction.Domain.Enuns;
using System;

namespace _4Lab.Satisfaction.Domain.Entities
{
    public class TecnicalArea : Entity<Guid>
    {
        public Quantitative WaitingTime { get; set; }
        public Quantitative ProfissionalHability { get; set; }
        public Quantitative ExamOrientation { get; set; }
    }
}
