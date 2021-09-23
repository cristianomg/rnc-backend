using _4Lab.Core.DomainObjects.Enums;
using Newtonsoft.Json;
using System;

namespace _4Lab.Occurrences.Application.DTOs
{
    public class DtoRiskAnalysisInput
    {
        public Guid OccurrenceRegisterId { get; set; }
        public OccurrenceRiskType OccurenceRisk { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public string UserName { get; set; }
    }
}
