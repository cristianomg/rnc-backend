using System.ComponentModel;

namespace Domain.ValueObjects
{
    public enum OccurrenceClassificationType : int
    {
        [Description("Near miss")]
        NearMiss = 1,
        [Description("Eventos adversos")]
        AdverseEvent,
        [Description("Evento sem dano")]
        UndamagedEvent
    }
} 
