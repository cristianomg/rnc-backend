using Domain.Dtos.Responses;

namespace Domain.Dtos.Inputs
{
    public class DtoSetor
    {
        /// <summary>
        /// Id do setor
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do setor
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Dados do supervisor
        /// </summary>
        public DtoSupervisor Supervisor { get; set; }
    }
}
