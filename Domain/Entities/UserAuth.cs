using Domain.ValueObjects;
using System;

namespace Domain.Entities
{
    public class UserAuth : Entity<Guid>
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Senha
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Usuário
        /// </summary>
        public virtual User User { get; set; }
    }
}
