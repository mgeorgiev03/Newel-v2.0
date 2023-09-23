using AutoMapper;
using Newel.Server.Model;

namespace Service.ViewModels.ListViewModels
{
    public class ToDoListProfile : Profile
    {
        public ToDoListProfile()
        {
            CreateMap<ToDoList, ToDoListViewModel>().ReverseMap();
        }
    }
}
