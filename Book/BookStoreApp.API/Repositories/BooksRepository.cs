using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Book;
using DL.DatabaseSpecific;
using DL.EntityClasses;
using DL.Linq;
using LLBLGen.Linq.Prefetch;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace BookStoreApp.API.Repositories;

public class BooksRepository : GenericRepository<BookEntity>, IBooksRepository
{
    private readonly IDataAccessAdapter context;
    private readonly LinqMetaData linq;
    private readonly IMapper mapper;
    private readonly IDataAccessAdapter adapter;
    public BooksRepository(IMapper mapper, IDataAccessAdapter context, LinqMetaData linq) : base(context, linq, mapper)
    {
        this.mapper = mapper;
        this.context = context;
        this.linq = linq;
    }

    public async Task<List<BookReadOnlyDto>> GetAllBooksAsync()
    {
        return linq.Book
            .Include(q => q.Author)
            .ToList()
            .Select(zz => mapper.Map<BookReadOnlyDto>(zz))
            .ToList();
    }

    public async Task<BookDetailsDto> GetBookAsync(int id)
    {
        return mapper.Map<BookDetailsDto>(linq.Book
            .Include(q => q.Author)
            .FirstOrDefault(q => q.Id == id));
    }
}