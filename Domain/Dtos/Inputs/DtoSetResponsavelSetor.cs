using Domain.ValueObjects;

namespace Domain.Dtos.Inputs
{
    public class DtoSetResponsavelSetor
    {
        public SetorType SetorId { get; set; }
        public string UserEmail { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string UserName { get; set; }
    }
}
