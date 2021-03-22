using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Inputs
{
    public class DtoNaoConformidade
    {
        /// <summary>
        /// Id da não conformidade
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id do tipo de nao conformidade
        /// </summary>
        public int TipoNaoConformidadeId { get; set; }
        /// <summary>
        /// Descrição
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// Nome do tipo nao conformidade
        /// </summary>
        public string NomeTipoNaoConformidade { get; set; }
    }
}
