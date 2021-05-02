using Domain.ValueObjects;

namespace Domain.Dtos.Inputs
{
    public class DtoSetSupervisor
    {
        public SetorType SetorId { get; set; }
        public string UserEmail { get; set; }
    }
}
