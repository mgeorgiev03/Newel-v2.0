using API.Models.ListModel;
using AutoMapper;
using Newel.Server.Model;

namespace API.Models.LisrModel
{
    public class ListProfile : Profile
    {
        public ListProfile()
        {
            CreateMap<ListRequestModel, ToDoList>();
            CreateMap<ToDoList, ListResponseModel>();
        }
    }
}
