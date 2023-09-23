using System.ComponentModel.DataAnnotations;

namespace Newel.Server.Model
{
    public class ToDoItem : BaseEntity
    {
        [Required]
        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime DateTime { get; set; }

        public virtual List<ToDoItem> Subtasks { get; set; }
    }
}
