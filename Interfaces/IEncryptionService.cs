namespace PasswordManagerAPI.Interfaces
{
    public interface IEncryptionService
    {
        string EncryptPassword(string password);
        string DecryptPassword(string encryptedPassword);
        bool IsValidBase64(string value);
    }
}