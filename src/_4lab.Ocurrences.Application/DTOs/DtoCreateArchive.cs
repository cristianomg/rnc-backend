namespace _4lab.Ocurrences.Application.DTOs
{
    public class DtoCreateArchive
    {
        /// <summary>
        /// Nome do arquivo
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Arquivo em base64
        /// </summary>
        public string File { get; set; }
        /// <summary>
        /// Tipo do arquivo
        /// </summary>
        public string FileType { get; set; }
    }
}
