using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Account
    {
        [Required]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string? Username { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(15)]
        public string? Password { get; set; }

        [Required]
        [Range(18, 60)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Url]
        public string? Website { get; set; }
    }
}
