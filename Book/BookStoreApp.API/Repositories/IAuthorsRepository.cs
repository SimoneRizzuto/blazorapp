using System.Security.Cryptography.X509Certificates;
using BookStoreApp.API.Controllers;
using BookStoreApp.API.Data;

namespace BookStoreApp.API.Repositories
{
    public interface IAuthorsRepository : IGenericRepository<Author>
    {
        Task<AuthorDetailsDto> GetAuthorDetailsAsync(int id);
    }
}
