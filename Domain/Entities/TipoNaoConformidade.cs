using System.Linq;

namespace Domain.Entities
{
    public class TipoNaoConformidade : Entity<int>
    {
        public string NomeTipoNaoConformidade { get; set; }
        public virtual IEnumerable<NaoConformidade> NaoConformidades { get; set; }
    }
}
