using Domain.ValueObjects;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class UserPermission : Entity<UserPermissionType>
    {
        /// <summary>
        /// Nome da permissão
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Usuários com a permissão
        /// </summary>
        public virtual IEnumerable<User> Users { get; set; }
    }
}
