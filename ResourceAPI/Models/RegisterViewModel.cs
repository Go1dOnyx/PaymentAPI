using System.ComponentModel.DataAnnotations;

namespace ResourceAPI.Models
{
    public class RegisterViewModel
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? FirstName { get; set; }
        public string? MiddleName { get; set;}

        [Required]
        public string? LastName { get; set;}
        public bool Status { get; set; }
    }
}
