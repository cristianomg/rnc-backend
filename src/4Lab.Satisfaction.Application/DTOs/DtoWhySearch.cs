﻿using _4Lab.Satisfaction.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Lab.Satisfaction.Application.DTOs
{
    public class DtoWhySearch
    {
        public Questions ResearchQuestions { get; set; }
        public string? Description { get; set; }
        public string NomeEnum { get; set; }
    }
}
