using Domain.Configs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using Domain.Models.Helps;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class RecoveryPasswordService : AbstractService, IRecoveryPasswordService
    {
        private readonly IEsqueciSenha _esqueciSenha;
        private readonly char[] ArrayAlph = "abcdefghijklm".ToCharArray();
        private readonly IUserAuthRepository _userAuthRepository;
        private readonly ICryptograph _cryptograph;
        private readonly string _jwtSecretKey;
        public RecoveryPasswordService(IUserAuthRepository userAuthRepostory, ICryptograph cryptograph,
                                 IOptions<CryptographConfig> cryptographConfig, IEsqueciSenha esqueciSenha)
        {
            _userAuthRepository = userAuthRepostory;
            _cryptograph = cryptograph;
            _jwtSecretKey = cryptographConfig.Value.JwtSecretKey;
            _esqueciSenha = esqueciSenha;
        }

        private string RandomPassword()
        {
            int tamanhoPass = 6;
            int tam = ArrayAlph.Length;
            string password = string.Empty;
            for (int i = 0; i < tamanhoPass; i++)
            {
                Random random = new Random();
                int codigo = Convert.ToInt32(random.Next(0, tam - 1).ToString());

                password += ArrayAlph[codigo];
            }

            return password;
        }


        public async Task<ResponseService> Execute(string email)
        {

            var hasUserWithEmail = await _userAuthRepository
               .GetAll();

            var user = hasUserWithEmail.FirstOrDefault();

            if (user == null)
                return GenerateErroServiceResponse("O email não foi encontrado.");

            var newPassword = RandomPassword();

            user.Password = _cryptograph.EncryptPassword(newPassword);

            await _userAuthRepository.Update(user);

            await _userAuthRepository.SaveChanges();

            await _esqueciSenha.EnviarEmailParaEsqueciSenha(email, user.User.Name, newPassword);

            return GenerateSuccessServiceResponse();
        }
    }
}
