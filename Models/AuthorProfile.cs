namespace apiwithdb.Models
{
    public class AuthorProfile
    {
        public Guid Id { get; set; }           // Clave primaria y también FK
        public string Biography { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;

        // Navigation property (uno a uno)
        public Author Author { get; set; } = null!;
    }

}
