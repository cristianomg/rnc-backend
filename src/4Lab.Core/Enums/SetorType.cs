using System.ComponentModel;

namespace _4Lab.Core.DomainObjects.Enums
{
    public enum SetorType : int
    {
        [Description("Coleta")]
        Coleta = 1,
        [Description("Microbiologia")]
        Microbiologia,
        [Description("Parasitologia")]
        Parasitologia,
        [Description("Imunologia")]
        Imunologia,
        [Description("Hematologia")]
        Hematologia,
        [Description("Triagem")]
        Triagem,
        [Description("Recepção")]
        Recepcao, 
        [Description("Almoxarifado")]
        Almoxarifado,
        [Description("Bioquímica")]
        Bioquimica,
        [Description("Uroanálise")]
        Uroanalise,
        [Description("Qualidade")]
        Qualidade,
        [Description("Coordenação")]
        Coordenação,
    }
}
