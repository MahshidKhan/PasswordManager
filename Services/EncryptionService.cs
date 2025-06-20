using System.Text;
using PasswordManagerAPI.Interfaces;

namespace PasswordManagerAPI.Services
{
    public class EncryptionService : IEncryptionService
    {
        public string EncryptPassword(string password)
        {
            try
            {
                if (string.IsNullOrEmpty(password))
                    throw new ArgumentException("Password cannot be null or empty");

                byte[] bytes = Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(bytes);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to encrypt password: {ex.Message}", ex);
            }
        }

        public string DecryptPassword(string encryptedPassword)
        {
            try
            {
                if (string.IsNullOrEmpty(encryptedPassword))
                    throw new ArgumentException("Encrypted password cannot be null or empty");

                if (!IsValidBase64(encryptedPassword))
                    throw new ArgumentException("Invalid Base64 format");

                byte[] bytes = Convert.FromBase64String(encryptedPassword);
                return Encoding.UTF8.GetString(bytes);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to decrypt password: {ex.Message}", ex);
            }
        }

        public bool IsValidBase64(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            try
            {
                Convert.FromBase64String(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}