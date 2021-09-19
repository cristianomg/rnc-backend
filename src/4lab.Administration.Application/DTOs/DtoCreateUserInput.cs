using Domain.ValueObjects;

namespace _4lab.Administration.Application.DTOs
{
    public class DtoCreateUserInput
    {
        public string CompleteName { get; set; }
        public string Email { get; set; }
        public string Enrollment { get; set; }
        public SetorType Setor { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public UserPermissionType UserPermission { get; set; }
    }
}
