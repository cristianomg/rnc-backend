using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Dtos.Responses
{
    public class DtoNonComplianceRegisterGroup
    {
        public string NonCompliance { get; set; }
        public int Quantity { get; set; }
    }
}
