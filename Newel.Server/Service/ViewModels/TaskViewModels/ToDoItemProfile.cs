using AutoMapper;
using Newel.Server.Model;

namespace Service.ViewModels.TaskViewModels
{
    public class ToDoItemProfile : Profile
    {
        public ToDoItemProfile()
        {
            CreateMap<ToDoItem, ToDoItemViewModel>().ReverseMap();
        }
    }
}
