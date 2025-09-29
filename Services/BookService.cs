using apiwithdb.Models;
using apiwithdb.Models.dtos;
using apiwithdb.Repositories;

namespace apiwithdb.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        public BookService(IBookRepository repo) => _repo = repo;

        public async Task<Book> Create(CreateBookDto dto)
        {
            if (dto.Year < 1900) throw new InvalidOperationException("Year must be between 1900 and current year.");
            var book = new Book { Id = Guid.NewGuid(), Title = dto.Title.Trim(), Year = dto.Year };
            await _repo.Add(book);
            return book;
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = await _repo.GetById(id);
            if (existing is null) return false;
            await _repo.Delete(id);
            return true;
        }

        public Task<IEnumerable<Book>> GetAll() => _repo.GetAll();
        public Task<Book?> GetById(Guid id) => _repo.GetById(id);
    }
}
