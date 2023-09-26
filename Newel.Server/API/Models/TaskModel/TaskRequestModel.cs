using System.ComponentModel.DataAnnotations;

namespace API.Models.TaskModel
{
    public class TaskRequestModel
    {
        [Required]
        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime DateTime { get; set; }
    }
}
