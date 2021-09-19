using _4Lab.Core.DomainObjects;
using _4Lab.Core.DomainObjects.Enums;
using System.Collections.Generic;

namespace _4Lab.Administration.Domain.Models
{
    public class UserPermission : Entity<UserPermissionType>
    {
        public string Name { get; private set; }
        public virtual IEnumerable<User> Users { get; private set; }

        public UserPermission(UserPermissionType id, string name, IEnumerable<User> users)
        {
            Id = id;
            Name = name;
            Users = users;
        }
    }
}
