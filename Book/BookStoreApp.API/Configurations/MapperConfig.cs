using AutoMapper;
using BookStoreApp.API.Controllers;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;
using BookStoreApp.API.Models.Book;
using BookStoreApp.API.Models.User;
using DL.EntityClasses;

namespace BookStoreApp.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDto, AuthorEntity>().ReverseMap();
            CreateMap<AuthorUpdateDto, AuthorEntity>().ReverseMap();
            CreateMap<AuthorReadOnlyDto, AuthorEntity>().ReverseMap();
            CreateMap<AuthorDetailsDto, AuthorEntity>().ReverseMap();

            CreateMap<BookCreateDto, BookEntity>().ReverseMap();
            CreateMap<BookUpdateDto, BookEntity>().ReverseMap();

            CreateMap<BookEntity, BookReadOnlyDto>()
                .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
                .ReverseMap();
            CreateMap<BookEntity, BookDetailsDto>()
                .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
                .ReverseMap();

            CreateMap<AspNetUserEntity, UserDto>()
                .ReverseMap();
        }
    }
}
