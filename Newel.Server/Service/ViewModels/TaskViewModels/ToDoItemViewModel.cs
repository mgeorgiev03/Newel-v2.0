namespace Service.ViewModels.TaskViewModels
{
    public class ToDoItemViewModel
    {
        public string Text { get; set; }

        public bool IsCompleted { get; set; }     

        public DateTime DateTime { get; set; }

        public virtual ICollection<ToDoItemViewModel> Subtasks { get; set; }
    }
}
