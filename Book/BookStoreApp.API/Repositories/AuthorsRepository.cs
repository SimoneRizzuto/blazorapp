using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStoreApp.API.Controllers;
using BookStoreApp.API.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Repositories;

public class AuthorsRepository : GenericRepository<Author>, IAuthorsRepository
{
    private readonly BookStoreDBContext context;
    private readonly IMapper mapper;
    public AuthorsRepository(BookStoreDBContext context, IMapper mapper) : base(context)
    {
        this.context = context;
        this.mapper = mapper;
    }
    public async Task<AuthorDetailsDto> GetAuthorDetailsAsync(int id)
    {
        var author = await context.Authors
            .Include(q => q.Books)
            .ProjectTo<AuthorDetailsDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(q => q.Id == id);

        return author;
    }
}