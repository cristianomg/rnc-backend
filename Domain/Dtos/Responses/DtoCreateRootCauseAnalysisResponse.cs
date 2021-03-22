namespace Domain.Dtos.Responses
{
    public class DtoCreateRootCauseAnalysisResponse
    {
        /// <summary>
        /// Id do registro de não conformidade a ser analisado
        /// </summary>
        public int NonComplianceRegisterId { get; set; }
        /// <summary>
        /// Descrição da analise
        /// </summary>
        public string Analyze { get; set; }
    }
}
