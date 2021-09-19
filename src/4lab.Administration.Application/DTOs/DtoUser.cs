using Domain.ValueObjects;

namespace _4lab.Administration.Application.DTOs
{
    public class DtoUser
    {
        public string CompleteName { get; set; }
        public string Email { get; set; }
        public string Enrollment { get; set; }
        public SetorType Setor { get; set; }
    }
}
