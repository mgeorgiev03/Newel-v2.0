namespace Newel.Web.Models.Task
{
    public class TaskRequestModel
    {
        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? DateTime { get; set; }
    }
}
