using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Inputs
{
    public class DtoTipoNaoConformidade
    {
        public int Id { get; set; }
        public string NomeTipoNaoConformidade { get; set; }
        public IEnumerable<DtoNaoConformidade> NaoConformidades { get; set; }
    }
}
