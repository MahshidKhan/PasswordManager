using PasswordManagerAPI.Data;
using PasswordManagerAPI.Interfaces;
using PasswordManagerAPI.Models;
using PasswordManagerAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PasswordManagerAPI.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordContext _context;
        private readonly IEncryptionService _encryptionService;

        public PasswordService(PasswordContext context, IEncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }

        public async Task<IEnumerable<PasswordEntry>> GetAllPasswordsAsync()
        {
            return await _context.Passwords.ToListAsync();
        }

        public async Task<PasswordEntry?> GetPasswordByIdAsync(int id)
        {
            return await _context.Passwords.FindAsync(id);
        }

        public async Task<PasswordWithDecryptedResponse?> GetPasswordWithDecryptedAsync(int id)
        {
            var password = await _context.Passwords.FindAsync(id);
            if (password == null) return null;

            var decryptedPassword = _encryptionService.DecryptPassword(password.EncryptedPassword);
            
            return new PasswordWithDecryptedResponse
            {
                Id = password.Id,
                Category = password.Category,
                App = password.App,
                UserName = password.UserName,
                DecryptedPassword = decryptedPassword,
                CreatedAt = password.CreatedAt,
                UpdatedAt = password.UpdatedAt
            };
        }

        public async Task<PasswordEntry> AddPasswordAsync(PasswordCreateRequest request)
        {
            var encryptedPassword = _encryptionService.EncryptPassword(request.Password);
            
            var passwordEntry = new PasswordEntry
            {
                Category = request.Category,
                App = request.App,
                UserName = request.UserName,
                EncryptedPassword = encryptedPassword,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Passwords.Add(passwordEntry);
            await _context.SaveChangesAsync();
            
            return passwordEntry;
        }

        public async Task<PasswordEntry?> UpdatePasswordAsync(int id, PasswordUpdateRequest request)
        {
            var existingPassword = await _context.Passwords.FindAsync(id);
            if (existingPassword == null) return null;

            existingPassword.Category = request.Category;
            existingPassword.App = request.App;
            existingPassword.UserName = request.UserName;
            existingPassword.EncryptedPassword = _encryptionService.EncryptPassword(request.Password);
            existingPassword.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existingPassword;
        }

        public async Task<bool> DeletePasswordAsync(int id)
        {
            var password = await _context.Passwords.FindAsync(id);
            if (password == null) return false;

            _context.Passwords.Remove(password);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}