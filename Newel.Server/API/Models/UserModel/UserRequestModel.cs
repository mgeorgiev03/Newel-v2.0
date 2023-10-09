using System.ComponentModel.DataAnnotations;

namespace API.Models.UserModel
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
        public string Password { get; set; } = string.Empty;
    }
}
