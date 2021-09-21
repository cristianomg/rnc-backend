using _4Lab.Core.DomainObjects.Enums;

namespace _4lab.Occurrences.Application.DTOs
{
    public class DtoSetSupervisor
    {
        public SetorType SetorId { get; set; }
        public string UserEmail { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string UserName { get; set; }
    }
}
