using System.ComponentModel;

namespace Domain.ValueObjects
{
    public enum UserPermissionType : int 
    {   
        [Description("Funcionario")]
        Employee = 1,
        [Description("Supervisor")]
        Supervisor,
        [Description("Bio Médico de Qualidade")]
        QualityBiomedical
    }
}
