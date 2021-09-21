using _4Lab.Core.DomainObjects;
using _4Lab.Core.DomainObjects.Enums;
using System;
using System.Collections.Generic;

namespace _4lab.Ocurrences.Domain.Models
{
    public class NonComplianceRegister : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public OccurrenceClassificationType OccurrenceClassificationId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string RegisterHour { get; set; }
        public SetorType SetorId { get; set; }
        public string PeopleInvolved { get; set; }
        public string MoreInformation { get; set; }
        public string ImmediateAction { get; set; }
        public ICollection<NonCompliance> NonCompliances { get; set; }
        public virtual RootCauseAnalysis RootCauseAnalysis { get; set; }
        public virtual Setor Setor { get; set; }
        public virtual OccurrenceClassification OccurrenceClassification { get; set; }
        public OcurrencePendency? OcurrencePendency { get; set; }
        public bool HasRootCauseAnalysis() => RootCauseAnalysis != null;
    }
}
