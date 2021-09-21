using System.ComponentModel;

namespace _4Lab.Core.DomainObjects.Enums
{
    public enum UserPermissionType : int
    {
        [Description("Funcionario")]
        Employee = 1,
        [Description("Supervisor")]
        Supervisor,
        [Description("Biomédico de Qualidade")]
        QualityBiomedical
    }
}
