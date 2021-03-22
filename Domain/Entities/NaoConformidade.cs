using System.Collections.Generic;

namespace Domain.Entities
{
    public class NaoConformidade : Entity<int>
    {
        public int TipoNaoConformidadeId { get; set; }
        public string Descricao { get; set; }
        public virtual TipoNaoConformidade TipoNaoConformidade { get; set; }
        public virtual IEnumerable<NonComplianceRegister> NonCompliceRegisters  { get; set; }
    }
}
