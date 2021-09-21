using System.Security.Cryptography;
using System.Text;

namespace _4lab.Infrastructure.Authorization
{
    public class SHA256Cryptograph : ICryptograph
    {
        private readonly HashAlgorithm _algoritmo;
        public SHA256Cryptograph()
        {
            _algoritmo = SHA256.Create();
        }

        public string EncryptPassword(string password)
        {
            var encodedValue = Encoding.UTF8.GetBytes(password);
            var senhaEncriptada = _algoritmo.ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in senhaEncriptada)
            {
                sb.Append(caracter.ToString("X2"));
            }
            return sb.ToString();
        }

        public bool VerifyPassword(string password, string encryptedPassword) =>
            EncryptPassword(password) == encryptedPassword;
    }
}
