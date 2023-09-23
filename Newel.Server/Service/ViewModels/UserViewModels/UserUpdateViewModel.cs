using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels.UserViewModels
{
    public class UserUpdateViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
