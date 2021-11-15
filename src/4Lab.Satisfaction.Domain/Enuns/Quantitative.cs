using System.ComponentModel;

namespace _4Lab.Satisfaction.Domain.Enuns
{
    public enum Quantitative : int
    {
        [Description("Ótimo")]
        Excellent = 1,
        [Description("Bom")]
        Good,
        [Description("Regular")]
        Regular,
        [Description("Ruim")]
        Bad,
        [Description("Muito Ruim")]
        TooBad,
        [Description("Sim")]
        Yes,
        [Description("Talvez")]
        Maybe,
        [Description("Não")]
        No
    }
}
