using System.ComponentModel;

namespace _4Lab.Core.DomainObjects.Enums
{
    public enum OccurrenceType : int
    {
        [Description("De Processo")]
        Process = 1,
        [Description("De Auditoria")]
        Audit,
        [Description("Reclamação de cliente")]
        CustomerComplaint,
        [Description("De Indicador")]
        Indicator,
        [Description("Análise de Risco")]
        RiskAnalysis
    }
}
