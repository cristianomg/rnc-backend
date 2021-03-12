using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IEsqueciSenha
    {
        Task EnviarEmailParaEsqueciSenha(string email, string name, string senha);
    }
}
