using _4Lab.Core.Enums;
using System;

namespace _4Lab.Archives.Application.DTOs
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
        public EntityArchiveType EntityType { get; set; }
        public string EntityId { get; set; }
    }
}
