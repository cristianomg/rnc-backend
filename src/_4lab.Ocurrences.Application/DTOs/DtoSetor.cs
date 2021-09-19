using _4Lab.Core.DomainObjects.Enums;

namespace _4lab.Ocurrences.Application.DTOs
{
    public class DtoSetor
    {
        /// <summary>
        /// Id do setor
        /// </summary>
        public SetorType Id { get; set; }

        /// <summary>
        /// Nome do setor
        /// </summary>
        public string Name { get; set; }

        public int SupervisorId { get; set; }

        public string UpdatedBy { get; set; }
    }
}
