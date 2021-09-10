using System.ComponentModel;

namespace Domain.ValueObjects
{
    public enum UserPermissionType : int
    {
        [Description("Funcionario")]
        Employee = 1,
        [Description("Resposável do Setor")]
        ResponsibleFS,
        [Description("Analista de Qualidade")]
        AnalystBiomedical
    }
}
