using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Book;
using DL.EntityClasses;

namespace BookStoreApp.API.Repositories
{
    public interface IBooksRepository : IGenericRepository<BookEntity>
    {
        Task<List<BookReadOnlyDto>> GetAllBooksAsync();
        Task<BookDetailsDto> GetBookAsync(int id);
    }
}



