using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStoreApp.API.Controllers;
using BookStoreApp.API.Data;
using DL.DatabaseSpecific;
using DL.EntityClasses;
using DL.Linq;
using LLBLGen.Linq.Prefetch;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace BookStoreApp.API.Repositories;

public class AuthorsRepository : GenericRepository<AuthorEntity>, IAuthorsRepository
{
    private readonly IDataAccessAdapter context;
    private readonly LinqMetaData linq;
    private readonly IMapper mapper;
    private readonly IDataAccessAdapter adapter;
    public AuthorsRepository(IMapper mapper, IDataAccessAdapter context, LinqMetaData linq) : base(context, linq, mapper)
    {
        this.mapper = mapper;
        this.context = context;
        this.linq = linq;
    }

    public async Task<AuthorDetailsDto> GetAuthorDetailsAsync(int id)
    {
        /*var metaData = new LinqMetaData(adapter);

        var author2 = from a in metaData.Author where a.Id==id select a;*/

        var author = linq.Author
            .Include(q => q.Books)
            .Where(zz => zz.Id == id)
            .ToList()
            .Select(zz => mapper.Map<AuthorDetailsDto>(zz))
            .FirstOrDefault();

        return author;
    }

}