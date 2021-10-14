using _4Lab.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Lab.Occurrences.Domain.Models
{
    public class VerificationOfEffectiveness : Entity<Guid>
    {
        public Guid OccurrenceRegisterId { get; private set; }
        public string Description { get; private set; }

        public VerificationOfEffectiveness(Guid occurrenceRegisterId, string description, string createdBy)
        {
            this.OccurrenceRegisterId = occurrenceRegisterId;
            this.Description = description;
            this.CreatedBy = createdBy;
        }
    }
}
