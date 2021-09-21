namespace _4lab.Administration.Application.DTOs
{
    public class DtoCreateAuthResponse
    {
        public DtoUser User { get; set; }
        public string Token { get; set; }
        public string Permission { get; set; }
    }
}
