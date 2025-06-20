using PasswordManagerAPI.Models;
using PasswordManagerAPI.DTOs;

namespace PasswordManagerAPI.Interfaces
{
    public interface IPasswordService
    {
        Task<IEnumerable<PasswordEntry>> GetAllPasswordsAsync();
        Task<PasswordEntry?> GetPasswordByIdAsync(int id);
        Task<PasswordWithDecryptedResponse?> GetPasswordWithDecryptedAsync(int id);
        Task<PasswordEntry> AddPasswordAsync(PasswordCreateRequest request);
        Task<PasswordEntry?> UpdatePasswordAsync(int id, PasswordUpdateRequest request);
        Task<bool> DeletePasswordAsync(int id);
    }
}