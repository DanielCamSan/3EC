using apiwithdb.Models;
using apiwithdb.Models.dtos;
using apiwithdb.Repositories;

namespace apiwithdb.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }
        public async Task<Book> Create(CreateBookDto dto)
        {
            if(dto.Year<1900)
            {
                throw new InvalidOperationException("Year must be between 1900 and the current year.");
            }
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = dto.Title.Trim(),
                Year = dto.Year
            };
            await _repo.Add(book);
            return book;
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return false;
            await _repo.Delete(id);
            return true;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Book?> GetById(Guid id)
        {
            var book = await _repo.GetById(id);
            return book;
        }
    }
}
