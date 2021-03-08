using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class NaoConformidade
    {
        public int Id { get; set; }
        public int TipoNaoConformidadeId { get; set; }
        public string Descricao { get; set; }
        public virtual TipoNaoConformidade TipoNaoConformidade { get; set; }
    }
}
