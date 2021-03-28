using Domain.ValueObjects;

namespace Domain.Dtos.Helps
{
    public class DtoUser
    {
        public string CompleteName { get; set; }
        public string Email { get; set; }
        public string Enrollment { get; set; }
        public SetorType Setor { get; set; }
        public string Crbm { get; set; }

    }
}
