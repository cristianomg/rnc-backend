namespace Domain.Dtos.Inputs
{
    public class DtoRootCauseAnalysisInput
    {
        /// <summary>
        /// Id do registro de não conformidade
        /// </summary>
        public int NonComplianceRegisterId { get; set; }
        /// <summary>
        /// Descrição da analise
        /// </summary>
        public string Analyze { get; set; }
        /// <summary>
        /// Plano de ação
        /// </summary>
        public DtoActionPlainInput ActionPlain { get; set; }

    }
}
