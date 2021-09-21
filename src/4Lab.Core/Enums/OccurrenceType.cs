using System.ComponentModel;

namespace _4Lab.Core.DomainObjects.Enums
{
    public enum OccurrenceType : int
    {
        [Description("Pre-Analítica")]
        PreAnalitica = 1,
        [Description("Analítica")]
        Analitica,
        [Description("Pos-Analítica")]
        PosAnalitica
    }
}
