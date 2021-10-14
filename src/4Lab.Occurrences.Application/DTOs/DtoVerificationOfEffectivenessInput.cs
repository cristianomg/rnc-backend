using System;
using System.Text.Json.Serialization;

namespace _4Lab.Occurrences.Application.DTOs
{
    public class DtoVerificationOfEffectivenessInput
    {
        public Guid OccurrenceRegisterId { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public string UserName { get; set; }
    }
}
