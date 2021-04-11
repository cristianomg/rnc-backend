using Domain.Interfaces.Services;
using System.Text;
using System.Threading.Tasks;

namespace Data.Rnc.Repositories
{
    public class EsqueciSenha : IEsqueciSenha
    {
        public readonly ISenderEmail _senderEmail; 
        public EsqueciSenha(ISenderEmail senderEmail)
        {
            _senderEmail = senderEmail;
        }
        public async Task SendEmailToForgetpassword(string email, string name, string password)
        {
            StringBuilder template = new StringBuilder();
            template.AppendLine($"Olá caro {name}");
            template.AppendLine("Você está recebendo este email porque esqueceu sua senha e por isso nós da equipe criamos uma nova senha provisória para você");
            template.AppendLine("");
            template.AppendLine($"Aqui está sua nova senha: {password}");
            template.AppendLine("Orientamos que você a troque pois a mesma é apenas provisória");
            template.AppendLine("");
            template.AppendLine("Atenciosamente, time do RNC");

            var subjectEmail = "Envio de senha provisória";

            await _senderEmail.SendEmail(email, template.ToString(), subjectEmail);
        }
    }
}
