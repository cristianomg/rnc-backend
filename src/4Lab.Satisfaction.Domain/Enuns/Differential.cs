using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Lab.Satisfaction.Domain.Enuns
{
    public enum Differential : int
    {
        [Description("Atendimento")]
        Attendence = 1,
        [Description("Agilidade")]
        Agility,
        [Description("Resultados")]
        RapidResults,
        [Description("Tratamento diferenciado")]
        DefferentialTreatment,
        [Description("Cafézinho")]
        Coffe,
        [Description("Localização")]
        Localization,
        [Description("Conforto")]
        Confort,
        [Description("Profissionais")]
        Professionals,
        [Description("Outros")]
        Others

    }
}
