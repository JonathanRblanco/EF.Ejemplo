using AutoMapper;
using EF.Business.Commands;
using EF.Business.Queries;
using EF.Domian.Models;

namespace EF.Business.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<TodoCreateCommand, Todo>().ReverseMap();
            CreateMap<Todo, TodoCreateCommandResponse>().ReverseMap();
            CreateMap<Todo, TodoGetAllQueryResponse>().ReverseMap();
        }
    }
}
