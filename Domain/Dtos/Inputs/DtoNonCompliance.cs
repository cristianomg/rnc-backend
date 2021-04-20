﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Inputs
{
    public class DtoNonCompliance
    {
        /// <summary>
        /// Id da não conformidade
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id do tipo de não conformidade
        /// </summary>
        public int TypeNonComplianceId { get; set; }
        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Nome do tipo da não conformidade
        /// </summary>
        public string NameNonCompliance { get; set; }
    }
}