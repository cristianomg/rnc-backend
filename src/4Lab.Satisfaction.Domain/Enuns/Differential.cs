using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Lab.Satisfaction.Domain.Enuns
{
    public enum Differential
    {
        [Description("Atendimento")]
        Attendence = 1,
        [Description("Agilidade")]
        Agility,
        [Description("Resultados")]
        RapidResults,
        [Description("Tratamento Diferenciado")]
        DefferentialTreatment,
        [Description("Cafezinho")]
        Coffe,
        [Description("Localização")]
        Localization,
        [Description("Conforto")]
        Confort,
        [Description("Proficionais")]
        Proficinals,
        [Description("Outros")]
        Others

    }
}
