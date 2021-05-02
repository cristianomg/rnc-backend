namespace Domain.Dtos.Inputs
{
    public class DtoActionPlainQuestionInput
    {
        /// <summary>
        /// Id das perguntas no plano de ação
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Descrição da pergunta
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Id do plano de ação
        /// </summary>
        public int? ActionPlainId { get; set; }
        /// <summary>
        /// Resposta
        /// </summary>
        public string Response { get; set; }
    }
}
