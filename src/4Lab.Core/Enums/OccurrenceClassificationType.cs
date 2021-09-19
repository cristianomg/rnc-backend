using System.ComponentModel;

namespace _4Lab.Core.DomainObjects.Enums
{
    public enum OccurrenceClassificationType : int
    {
        [Description("Near miss")]
        NearMiss = 1,
        [Description("Evento adverso leve")]
        MildAdverseEvent,
        [Description("Evento adverso moderado")]
        ModerateAdverseEvent,
        [Description("Evento adverso grave")]
        SeriousAdverseEvent,
        [Description("Evento sem dano")]
        UndamagedEvent,
        [Description("Não conformidade")]
        NonCompliance
    }
} 
