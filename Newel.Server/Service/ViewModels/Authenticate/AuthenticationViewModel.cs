using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels.Authenticate
{
    public class AuthenticationViewModel
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
