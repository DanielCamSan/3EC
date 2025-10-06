// Namespace sugerido: apiwithdb.Models.DTOS
using System.ComponentModel.DataAnnotations;

namespace apiwithdb.Models.dtos
{
    // Para listados (tabla, combos)
    public record AuthorListDto(
        Guid Id,
        string Name,
        int BooksCount // útil para UI
    );

    // Para detalle (incluye, si quieres, títulos de libros)
    public record AuthorDetailDto(
        Guid Id,
        string Name,
        List<SimpleBookDto> Books // proyección ligera
    );

    // Para crear
    public record CreateAuthorDto(
        [Required, StringLength(200, MinimumLength = 2)]
        string Name
    );
    public record UpdateAuthorDto(
    [Required, StringLength(200, MinimumLength = 2)]
        string Name
);

    // Book “ligero” para anidar en AuthorDetailDto
    public record SimpleBookDto(
        Guid Id,
        string Title,
        int Year
    );
}
