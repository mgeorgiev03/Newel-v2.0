namespace Newel.Web.Models.Task
{
    public class TaskResponseMOdel
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime DateTime { get; set; }
    }
}
