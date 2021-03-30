using Domain.ValueObjects;

namespace Domain.Dtos.Helps
{
    public class DtoUserAtivo
    {
        public int Id { get; set; }
        public string CompleteName { get; set; }
        public string Email { get; set; }
        public string Enrollment { get; set; }
        public string Setor { get; set; }
        public string Crbm { get; set; }
        public bool Ativo { get; set; }

    }
}
