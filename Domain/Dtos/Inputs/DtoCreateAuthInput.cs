namespace Domain.Dtos.Inputs
{
    public class DtoCreateAuthInput
    {
        /// <summary>
        /// Email do usuário
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Senha do usuário
        /// </summary>
        public string Password { get; set; }
    }
}
