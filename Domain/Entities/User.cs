using Domain.ValueObjects;
using System;

namespace Domain.Entities
{
    public class User : Entity<int>
    {
        /// <summary>
        /// Nome completo
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Id autenticação do usuário
        /// </summary>
        public int UserAuthId { get; set; }
        /// <summary>
        /// Matricula
        /// </summary>
        public string Enrollment { get; set; }
        /// <summary>
        /// Dados de autenticação do usuário
        /// </summary>
        public virtual UserAuth UserAuth { get; set; }
        /// <summary>
        /// Id da permissão do usuário
        /// </summary>
        public UserPermissionType UserPermissionId { get; set; }
        /// <summary>
        /// Dados da permissão do usuário
        /// </summary>
        public virtual UserPermission UserPermission { get; set; }

    }
}
