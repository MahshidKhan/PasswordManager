namespace PasswordManagerAPI.Models
{
    public class PasswordEntry
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string App { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string EncryptedPassword { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}