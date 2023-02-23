using AutoMapper;
using Database.Entity;
using Model.Dtos;

namespace Book_Store.AutoMapper
{
    public class DataAutomapperProfile : Profile
    {
        public DataAutomapperProfile()
        {
            CreateMap<BookDto, Books>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }

    }
}
