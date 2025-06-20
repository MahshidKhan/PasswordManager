namespace PasswordManagerAPI.DTOs
{
    public class PasswordWithDecryptedResponse
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string App { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string DecryptedPassword { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}