using System.ComponentModel.DataAnnotations;

namespace Newel.Server.Model
{
    public class User : BaseEntity
    {
        [Required]
        [MinLength(6), MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6), MaxLength(30)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "The password must contain at least one digit, one upper case letter, one lower case letter and one special symbol(@$!%*?&)!")]
        public string Password { get; set; } = string.Empty;

        public virtual ICollection<ToDoList> Lists { get; set; } = new List<ToDoList>();
    }
}
