using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class TipoNaoConformidade
    {
        public int Id { get; set; }
        public string NomeTipoNaoConformidade { get; set; }
        public virtual IQueryable<NaoConformidade> NaoConformidades { get; set; }
    }
}
