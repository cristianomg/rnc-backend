using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Lab.Occurrences.Application.DTOs
{
    public class DtoVerificationOfEffectivenessInput
    {
        public Guid OccurrenceRegisterId { get; set; }
        public string Description { get; set; }
    }
}
