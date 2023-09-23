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
        public string Password { get; set; } = string.Empty;

        public virtual ICollection<ToDoList> Lists { get; set; } = new List<ToDoList>();
    }
}
