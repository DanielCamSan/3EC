using System.ComponentModel.DataAnnotations;

namespace apiwithdb.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public int Year { get; set; }
        public Guid? AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
