using _4Lab.Core.DomainObjects.Enums;
using System;

namespace _4lab.Administration.Application.DTOs
{
    public class DtoUserResponse
    {
        public Guid Id { get; set; }
        public string CompleteName { get; set; }
        public string Email { get; set; }
        public string Enrollment { get; set; }
        public string Setor { get; set; }
        public UserPermissionType UserPermissionId { get; set; }
    }
}
