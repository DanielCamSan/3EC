using apiwithdb.Models;
using Microsoft.EntityFrameworkCore;

namespace apiwithdb.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Author> Authors => Set<Author>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).IsRequired().HasMaxLength(200);
                b.Property(x => x.Year).IsRequired();
                // Índice útil para queries por autor (y compuesta opcional abajo)
                b.HasIndex(x => x.AuthorId);
                // (Opcional) Evitar títulos duplicados por autor:
                // b.HasIndex(x => new { x.Title, x.AuthorId }).IsUnique();
            });
            modelBuilder.Entity<Author>(a =>
            {
                a.HasKey(x => x.Id);
                a.Property(x => x.Id).ValueGeneratedNever();
                a.Property(x => x.Name).IsRequired().HasMaxLength(200);
                a.HasMany(x => x.Books).WithOne(b => b.Author).HasForeignKey(b => b.AuthorId).OnDelete(DeleteBehavior.Restrict); // 👍 evita borrar autor si tiene libros;
            });
        }
    }
}
