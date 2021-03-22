using System;

namespace Domain.Dtos.Responses
{
    public class DtoNonComplianceRegisterResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public string Setor { get; set; }
        public string NonComplianceType { get; set; }
        public string NonCompliance { get; set; }
        public string PeopleInvolved { get; set; }
    }
}
