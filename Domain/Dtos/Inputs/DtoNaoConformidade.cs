using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Inputs
{
    public class DtoNaoConformidade
    {
        public int Id { get; set; }
        public int TipoNaoConformidadeId { get; set; }
        public string Descricao { get; set; }
        public string NomeTipoNaoConformidade { get; set; }
    }
}
