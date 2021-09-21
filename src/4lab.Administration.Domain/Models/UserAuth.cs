using _4Lab.Core.DomainObjects;
using System;

namespace _4Lab.Administration.Domain.Models
{
    public class UserAuth : Entity<Guid>
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public virtual User User { get; private set; }

        public UserAuth(string email, string password)
        {
            Email = email;
            Password = password;
        }
        protected UserAuth() { }


        public void SetPassword(string passowrd)
        {
            if (!string.IsNullOrEmpty(passowrd))
                Password = passowrd;
            else
                throw new System.Exception("Senha do usuário não pode ser nula ou vazia.");
        }
    }
}
