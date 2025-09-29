using apiwithdb.Models;

namespace apiwithdb.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book?> GetById(Guid id);
        Task Add(Book book);
        Task Delete(Guid id);
    }
}
