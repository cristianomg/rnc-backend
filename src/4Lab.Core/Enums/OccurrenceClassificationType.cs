using System.ComponentModel;

namespace _4Lab.Core.DomainObjects.Enums
{
    public enum OccurrenceClassificationType : int
    {
        [Description("Não conformidade")]
        NomComplience = 1,
        [Description("Não conformidade em potencial")]
        NomCompliencePotencial,
        [Description("Oportunidade de melhorias")]
        ImprovementOpportunity,
    }
}
