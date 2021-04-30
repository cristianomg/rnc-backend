namespace Domain.Interfaces.Util
{
    public interface ICryptograph
    {
        string EncryptPassword(string password);
        bool VerifyPassword(string password, string encryptedPassword);
    }
}
