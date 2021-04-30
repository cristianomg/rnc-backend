using Domain.ValueObjects;

namespace Domain.Dtos.Requests
{
    /// <summary>
    /// Dto responsável por receber os dados de criação do usuário
    /// </summary>
    public class DtoCreateUserInput
    {
        /// <summary>
        /// Nome completo
        /// </summary>
        public string CompleteName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Matricula
        /// </summary>
        public string Enrollment { get; set; }
        /// <summary>
        /// Setor
        /// </summary>
        public SetorType Setor { get; set; }
        /// <summary>
        /// Senha
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Confirmação de senha
        /// </summary>
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// Cargo do usuário
        /// </summary>
        public UserPermissionType UserPermission { get; set; }
        

    }
}
