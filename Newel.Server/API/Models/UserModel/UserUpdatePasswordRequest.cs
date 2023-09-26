using System.ComponentModel.DataAnnotations;

namespace API.Models.UserModel
{
    public class UserUpdatePasswordRequest : BaseResponseModel
    {
        [Required]
        [MinLength(6), MaxLength(30)]
        public string OldPassword { get; set; }

        [Required]
        [MinLength(6), MaxLength(30)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "The password must contain at least one digit, one upper case letter, one lower case letter and one special symbol(@$!%*?&)!")]
        public string NewPassword { get; set; }
    }
}
