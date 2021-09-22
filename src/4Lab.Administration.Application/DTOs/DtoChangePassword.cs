namespace _4lab.Administration.Application.DTOs
{
    public class DtoChangePassword
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
