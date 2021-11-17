using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Lab.Satisfaction.Domain.Enuns
{
    public enum Questions
    {
        [Description("Por recomendação médica")]
        MedicalRecommendation = 1,
        [Description("Por indicação de amigos ou parente")]
        FriednOrRelatives,
        [Description("Pela localização")]
        Location,
        [Description("Por ter visto propaganda ou anúncio")]
        Advertising,
        [Description("Como opção de convênio")]
        IsuranceOption,
        [Description("Outros")]
        Others,
        [Description("Onde")]
        Where,
        [Description("Qual")]
        Which

    }
}
