using System.Collections.Generic;

namespace Domain.Dtos.Inputs
{
    public class DtoRootCauseAnalysisInput
    {
        /// <summary>
        /// Id do registro de não conformidade
        /// </summary>
        public int NonComplianceRegisterId { get; set; }
        /// <summary>
        /// 5 Porques
        /// </summary>
        public List<DtoFiveWhat> FiveWhat { get; set; }
        /// <summary>
        /// Plano de ação
        /// </summary>
        public DtoActionPlainInput ActionPlain { get; set; }

        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string UserName { get; set; }
    }
}
