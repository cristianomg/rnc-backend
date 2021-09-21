namespace _4Lab.Infrastructure.Authorization
{
    public interface ITokenService
    {
        string GenerateToken(string id, string name, string role);
    }
}
