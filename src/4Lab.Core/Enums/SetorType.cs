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
        [Description("Imuno-hematologia")] 
        ImunoHematologia,
        [Description("Triagem")] 
        Triagem,
        [Description("Recepção")] 
        Recepcao, 
        [Description("Bioquímica")] 
        Bioquimica,
        [Description("Urinálise")] 
        Urinalise,
        [Description("Administrativo")] 
        Administrativo,
        [Description("Assistencial")] 
        Assistencial,
        [Description("Prestadores de serviço")] 
        PrestadoresDeServiço,
        [Description("Fornecedores")] 
        Fornecedores,
    }
}
