using System.ComponentModel.DataAnnotations;

namespace Newel.Web.Models.User
{
    public class LogInRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6), MaxLength(30)]
        public string Password { get; set; }
    }
}
