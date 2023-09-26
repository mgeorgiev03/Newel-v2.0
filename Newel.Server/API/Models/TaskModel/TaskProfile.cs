using AutoMapper;
using Newel.Server.Model;

namespace API.Models.TaskModel
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskRequestModel, ToDoItem>();
            CreateMap<ToDoItem, TaskResponseModel>();
        }
    }
}
