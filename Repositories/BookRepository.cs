using apiwithdb.Data;
using apiwithdb.Models;

namespace apiwithdb.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
           _books.Add(book);
        }

        public void Delete(Guid id)
        {
           _books.RemoveAll(b => b.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
           return _books;
        }

        public Book? GetById(Guid id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }
    }
}
