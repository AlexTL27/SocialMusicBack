using System.ComponentModel.DataAnnotations;

namespace SocialMusic.Models
{
    public class CLoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }
}
