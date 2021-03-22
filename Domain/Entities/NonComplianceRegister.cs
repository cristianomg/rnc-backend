﻿using System;

namespace Domain.Entities
{
    public class NonComplianceRegister : Entity<int>
    {
        public int UserId { get; set; }
        public int NonComplianceId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string RegisterHour { get; set; }
        public string Setor { get; set; }
        public string PeopleInvolved { get; set; }
        public string MoreInformation { get; set; }
        public string ImmediateAction { get; set; }

        public virtual User User { get; set; }
        public virtual NaoConformidade NonCompliance { get; set; }
        public virtual RootCauseAnalysis RootCauseAnalysis { get; set; }
    }
}