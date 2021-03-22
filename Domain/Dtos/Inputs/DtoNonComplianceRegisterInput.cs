using System;

namespace Domain.Dtos.Inputs
{
    public class DtoNonComplianceRegisterInput
    {
        /// <summary>
        /// Código da não conformidade aplicada ao registro
        /// </summary>
        public int NonComplianceId { get; set; }
        /// <summary>
        /// Data do registro
        /// </summary>
        public DateTime RegisterDate { get; set; }
        /// <summary>
        /// Hora do registro
        /// </summary>
        public string RegisterHour  { get; set; }
        /// <summary>
        /// Setor
        /// </summary>
        public string Setor { get; set; }
        /// <summary>
        /// Pessoas envolvidas
        /// </summary>
        public string PeopleInvolved { get; set; }
        /// <summary>
        /// Mais informações
        /// </summary>
        public string MoreInformation { get; set; }
        /// <summary>
        /// Ação imediata
        /// </summary>
        public string ImmediateAction { get; set; }

    }
}
