namespace PasswordManagerAPI.DTOs
{
    public class PasswordCreateRequest
    {
        public string Category { get; set; } = string.Empty;
        public string App { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class PasswordUpdateRequest
    {
        public string? Category { get; set; }
        public string? App { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}