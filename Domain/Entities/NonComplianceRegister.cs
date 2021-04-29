using Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class NonComplianceRegister : Entity<int>
    {
        public int UserId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string RegisterHour { get; set; }
        public SetorType SetorId { get; set; }
        public string PeopleInvolved { get; set; }
        public string MoreInformation { get; set; }
        public string ImmediateAction { get; set; }
        public virtual User User { get; set; }
        public ICollection<NonCompliance> NonCompliances{ get; set; }
        public virtual RootCauseAnalysis RootCauseAnalysis { get; set; }
        public virtual Setor Setor { get; set; }
    }
}
