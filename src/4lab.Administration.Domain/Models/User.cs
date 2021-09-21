using _4Lab.Core.DomainObjects;
using _4Lab.Core.DomainObjects.Enums;
using System;

namespace _4Lab.Administration.Domain.Models
{
    public class User : Entity<Guid>
    {
        public string Name { get; set; }
        public string Enrollment { get; set; }
        public SetorType SetorId { get; set; }

        public Guid UserAuthId { get; set; }
        public virtual UserAuth UserAuth { get; private set; }

        public UserPermissionType UserPermissionId { get; set; }
        public virtual UserPermission UserPermission { get; private set; }
        public User(string name, string enrollment, SetorType setorId, UserPermissionType userPermissionId, UserAuth userAuth)
        {
            Id = Guid.NewGuid();
            Name = name;
            Enrollment = enrollment;
            SetorId = setorId;
            UserAuth = userAuth;
            UserPermissionId = userPermissionId;
        }
        protected User() { }
    }
}
