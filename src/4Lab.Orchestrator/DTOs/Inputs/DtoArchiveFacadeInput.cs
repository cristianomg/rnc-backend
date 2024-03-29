﻿using _4Lab.Core.Enums;
using Newtonsoft.Json;
using System;

namespace _4Lab.Orchestrator.DTOs.Inputs
{
    public class DtoArchiveFacadeInput
    {
        [JsonIgnore]
        public Guid? Id { get; set; } = null;
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
