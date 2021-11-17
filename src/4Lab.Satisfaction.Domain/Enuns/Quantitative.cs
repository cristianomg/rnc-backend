using System.ComponentModel;

namespace _4Lab.Satisfaction.Domain.Enuns
{
    public enum Quantitative
    {
        [Description("Excelente")]
        Excellent = 1,
        [Description("Bom")]
        Good,
        [Description("Regualar")]
        Regular,
        [Description("Ruim")]
        Bad,
        [Description("Muitos Ruim")]
        TooBad,
        [Description("Sim")]
        Yes,
        [Description("Talvez")]
        Maybe,
        [Description("Não")]
        No
    }
}
