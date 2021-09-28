using System.ComponentModel;

namespace _4Lab.Core.DomainObjects.Enums
{
    public enum UserPermissionType : int
    {
        [Description("Funcionario")]
        Employee = 1,
        [Description("Responsável do Setor")]
        ResponsibleFS,
        [Description("Responsável Técnico")]
        ResponsibleT,
        [Description("Analista da Qualidade")]
        QualityAnalist
    }
}
