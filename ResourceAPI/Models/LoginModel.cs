namespace ResourceAPI.Models
{
    public class LoginModel
    {
        public string? UserEmail { get; set; }
        public string? Password { get; set; }
        public bool RemeberMe { get; set; }
    }
}
