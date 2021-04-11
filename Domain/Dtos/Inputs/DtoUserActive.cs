using Domain.ValueObjects;

namespace Domain.Dtos.Helps
{
    public class DtoUserActive
    {
        /// <summary>
        /// Id do usuário
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string CompleteName { get; set; }
        /// <summary>
        /// Email do usuário
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Matrícula do usuário
        /// </summary>
        public string Enrollment { get; set; }
        /// <summary>
        /// Setor do usuário
        /// </summary>
        public string Setor { get; set; }
        /// <summary>
        /// Crbm do usuário
        /// </summary>
        public string Crbm { get; set; }
        /// <summary>
        /// Flag ativo ou inativo
        /// </summary>
        public bool Active { get; set; }

    }
}
