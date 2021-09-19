using Domain.ValueObjects;

namespace Domain.Entities
{
    public class User : Entity<int>
    {
        public string Name { get; private set; }
        public int UserAuthId { get; private set; }
        public string Enrollment { get; private set; }
        public SetorType SetorId { get; private set; }
        public UserPermissionType UserPermissionId { get; private set; }
        public virtual UserAuth UserAuth { get; private set; }
        public virtual UserPermission UserPermission { get; private set; }

        public User(int id, string name, int userAuthId, string enrollment, SetorType setorId,
                    UserPermissionType userPermissionId, UserAuth userAuth, UserPermission userPermission)
        {
            Id = id;
            Name = name;
            UserAuthId = userAuthId;
            Enrollment = enrollment;
            SetorId = setorId;
            UserPermissionId = userPermissionId;
            UserAuth = userAuth;
            UserPermission = userPermission;
        }
    }
}
