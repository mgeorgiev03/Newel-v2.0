using System.ComponentModel.DataAnnotations;

namespace Newel.Server.Model
{
    public class ToDoList : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public Guid UserId { get; set; }

        public virtual List<ToDoItem> Tasks { get; set; }
    }
}
