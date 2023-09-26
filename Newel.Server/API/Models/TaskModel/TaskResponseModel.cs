namespace API.Models.TaskModel
{
    public class TaskResponseModel
    {
        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime DateTime { get; set; }
    }
}
