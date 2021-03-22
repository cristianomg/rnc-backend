using Domain.Dtos.Helps;
using Domain.Entities;

namespace Domain.Dtos.Responses
{
    public class DtoCreateAuthResponse
    {
        /// <summary>
        /// Dados do usuário
        /// </summary>
        public DtoUser User { get; set; }
        /// <summary>
        /// Token JWT
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Permissão do usuário
        /// </summary>
        public string Permission { get; set; }
    }
}
