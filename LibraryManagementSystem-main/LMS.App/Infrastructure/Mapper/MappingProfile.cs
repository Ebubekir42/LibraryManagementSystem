using AutoMapper;
using LMS.Entities.Models;
using LMS.Entities.Dtos;

namespace LMS.App.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForInsertion, Book>();
            CreateMap<BookDtoForUpdate, Book>().ReverseMap();
            CreateMap<AuthorDtoForInsertion, Author>();
            CreateMap<AuthorDtoForUpdate, Author>().ReverseMap();
            CreateMap<CategoryDtoForInsertion, Category>();
            CreateMap<CategoryDtoForUpdate, Category>().ReverseMap();
            CreateMap<UserDtoForInsertion, ApplicationUser>();
            CreateMap<UserDtoForUpdate, ApplicationUser>().ReverseMap();
            CreateMap<RegisterDto, ApplicationUser>();
            CreateMap<BookDtoForAddAsCopy, Book>().ReverseMap();
            CreateMap<BookDtoForDelete,Book>().ReverseMap();
        }
    }
}
