namespace _4lab.Infrastructure.Authorization
{
    public interface ICryptograph
    {
        string EncryptPassword(string password);
        bool VerifyPassword(string password, string encryptedPassword);
    }
}
