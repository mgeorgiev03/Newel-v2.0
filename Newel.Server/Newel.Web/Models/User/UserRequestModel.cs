using System.ComponentModel.DataAnnotations;

namespace Newel.Web.Models.User
{
    public class UserRequestModel : BaseRequestModel
    {
        [Required]
        [MinLength(6), MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6), MaxLength(30)]
        public string Password { get; set; } = string.Empty;
    }
}
