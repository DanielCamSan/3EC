using apiwithdb.Models;
using apiwithdb.Models.dtos;

namespace apiwithdb.Services
{
    public interface IBookService
    {
        Task<Book> Create(CreateBookDto dto);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<Book>> GetAll();
        Task<Book?> GetById(Guid id);
    }
}

