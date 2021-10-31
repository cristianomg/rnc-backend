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
        public Differential Description { get; set; }

    }
}
