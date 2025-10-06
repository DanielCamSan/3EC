using apiwithdb.Models;

namespace apiwithdb.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllWithBooks();
        Task<Author?> GetByIdWithBooks(Guid id);
        Task<bool> ExistsByName(string name);
        Task<bool> ExistsByNameExcludingId(string name, Guid excludeId);
        Task Add(Author author);
        Task Update(Author author);
        Task<bool> Delete(Guid id);   // false si no existe o FK bloquea
        Task<bool> HasBooks(Guid id); // para proteger borrado

        Task<bool> ExistsById(Guid id);
    }
}
