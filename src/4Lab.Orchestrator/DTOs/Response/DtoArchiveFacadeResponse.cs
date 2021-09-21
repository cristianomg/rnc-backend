namespace _4Lab.Orchestrator.DTOs.Response
{
    public class DtoArchiveFacadeResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Link para o arquivo
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Nome do arquivo
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Tipo do arquivo
        /// </summary>
        public string FileType { get; set; }
    }
}
