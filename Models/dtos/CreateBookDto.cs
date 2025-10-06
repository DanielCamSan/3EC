using System.ComponentModel.DataAnnotations;

namespace apiwithdb.Models.dtos
{
    public record CreateBookDto(
        [Required, StringLength(200)] string Title,
        [Range(0, 3000)] int Year,
        [Required] Guid AuthorId   // 👈 aquí viene el link
    );

    public record UpdateBookAuthorDto(
        [Required] Guid AuthorId    // para relinkear un libro existente
    );
}
