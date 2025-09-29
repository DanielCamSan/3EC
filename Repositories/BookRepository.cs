using apiwithdb.Models;
using apiwithdb.Data;
using Microsoft.EntityFrameworkCore;

namespace apiwithdb.Repositories
{
    public class BookRepository : IBookRepository
    {
        //private readonly List<Book> _books = new()
        //{
        //    new Book { Id = Guid.NewGuid(), Title = "Clean Code", Year = 2008 },
        //    new Book { Id = Guid.NewGuid(), Title = "Pragmatic Programmer", Year = 1999 },
        //    new Book { Id = Guid.NewGuid(), Title = "Refactoring", Year = 1999 }
        //};
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Book book)
        {
           await _context.Books.AddAsync(book);
        }

        public async Task Delete(Guid id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
           return await _context.Books.ToListAsync();
        }

        public async Task<Book?>  GetById(Guid id)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
