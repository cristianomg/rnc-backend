using _4Lab.Core.DomainObjects;
using _4Lab.Core.DomainObjects.Enums;
using _4Lab.Occurrences.Domain.Models;
using _4Lab.Occurrences.Domain.Strategy.CalculateOccurrenceRegisterDelayed;
using System;
using System.Collections.Generic;

namespace _4lab.Occurrences.Domain.Models
{
    public class OccurrenceRegister : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public OccurrenceRiskType? OccurrenceRiskId { get; set; }
        public OccurrenceClassificationType? OccurrenceClassificationId { get; set; }
        public OccurrenceType OccurrenceTypeId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string RegisterHour { get; set; }
        public SetorType? SetorId { get; set; }
        public string PeopleInvolved { get; set; }
        public string MoreInformation { get; set; }
        public string ImmediateAction { get; set; }
        public ICollection<Occurrence> Occurrences { get; set; }
        public virtual RootCauseAnalysis RootCauseAnalysis { get; set; }
        public virtual Setor Setor { get; set; }
        public virtual OccurrenceRisk OccurrenceRisk { get; set; }
        public virtual OccurrenceClassification OccurrenceClassification { get; set; }
        public OccurrencePendency? OccurrencePendency { get; set; }
        public bool HasAllAnalysis() => !OccurrencePendency.HasValue;
        public virtual TypeOccurrence OccurrenceType { get; set; }
        public virtual VerificationOfEffectiveness VerificatoinOfEffectiveness { get; set; }
        public DateTime? CreatedRootCauseAnalysis { get; set; }
        public DateTime? CreatedOcurrenceRisk { get; set; }
        public DateTime? CreatedVerificatoinOfEffectiveness { get; set; }


        public bool IsDelayed
        {
            get
            {
                switch (this.OccurrencePendency)
                {
                    case _4Lab.Core.DomainObjects.Enums.OccurrencePendency.RootCauseAnalysisAndActionPlan:
                        return new OccurrenceRegisterDelayedByRootCause().Calculate(this);
                    case _4Lab.Core.DomainObjects.Enums.OccurrencePendency.RiskRating:
                        return new OccurrenceRegisterDelayedByRisk().Calculate(this);
                    case _4Lab.Core.DomainObjects.Enums.OccurrencePendency.VerificationOfEffectiveness:
                        return new OccurrenceRegisterDelayedByVerificatoinOfEffectiveness().Calculate(this);
                    default:
                        return false;
                }
            }
        }

        public bool CanVerifyEffectiveness
        {
            get
            {
                if (this.CreatedOcurrenceRisk.HasValue)
                {
                    return DateTime.Now.Subtract(this.CreatedOcurrenceRisk.Value).TotalDays > 31;

                }
                else
                {
                    return false;
                }
            }
        }

    }
}