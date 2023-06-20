using System.ComponentModel.DataAnnotations;

namespace MegaMart.Entity
{
    public class UserCradential
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
