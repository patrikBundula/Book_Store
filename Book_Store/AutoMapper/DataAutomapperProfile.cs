using AutoMapper;
using Book_Store.Dtos;

namespace Book_Store.AutoMapper
{
    public class DataAutomapperProfile : Profile
    {
        public DataAutomapperProfile()
        {
            CreateMap<BookDto, Books>().ReverseMap();
            CreateMap<EditBookDto, Books>().ReverseMap();
        }

    }
}
