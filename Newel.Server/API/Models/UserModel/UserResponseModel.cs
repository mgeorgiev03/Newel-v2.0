using System.ComponentModel.DataAnnotations;

namespace API.Models.UserModel
{
    public class UserResponseModel : BaseResponseModel
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


        //public ICollection<Guid> ListGuids { get; set; }
    }
}
