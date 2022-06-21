using System.Security.Cryptography.X509Certificates;
using BookStoreApp.API.Controllers;
using BookStoreApp.API.Data;
using DL.EntityClasses;

namespace BookStoreApp.API.Repositories
{
    public interface IAuthorsRepository : IGenericRepository<AuthorEntity>
    {
        Task<AuthorDetailsDto> GetAuthorDetailsAsync(int id);
    }
}
