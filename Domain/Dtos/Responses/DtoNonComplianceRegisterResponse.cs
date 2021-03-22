using System;

namespace Domain.Dtos.Responses
{
    public class DtoNonComplianceRegisterResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do usuário que realizou o registro
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Data do registro
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Hora do registro
        /// </summary>
        public string Hour { get; set; }
        /// <summary>
        /// Setor
        /// </summary>
        public string Setor { get; set; }
        /// <summary>
        /// Tipo de não comformidade
        /// </summary>
        public string NonComplianceType { get; set; }
        /// <summary>
        /// Descrição da não conformidade
        /// </summary>
        public string NonCompliance { get; set; }
        /// <summary>
        /// Pessoas envolvidas
        /// </summary>
        public string PeopleInvolved { get; set; }
        /// <summary>
        /// Flag para informar se o registro de não conformidade já passou pela fase de analise de causa raiz
        /// </summary>
        public bool HasRootCauseAnalysis { get; set; }
    }
}
