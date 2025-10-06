// Namespace sugerido: apiwithdb.Models.DTOS
using System.ComponentModel.DataAnnotations;

namespace apiwithdb.Models.dtos
{
	// Para listados
	public record TagDto(
		Guid Id,
		string Name
	);

	// Para detalle (con cuántos libros está asociado)
	public record TagDetailDto(
		Guid Id,
		string Name,
		int BooksCount,
		List<SimpleBookDto> Books // opcional si quieres mostrar ejemplos
	);

	// Para crear
	public record CreateTagDto(
		[Required, StringLength(50, MinimumLength = 2)]
		string Name
	);

	// Para actualizar
	public record UpdateTagDto(
		[Required, StringLength(50, MinimumLength = 2)]
		string Name
	);

	// Reutiliza SimpleBookDto desde Authors DTOs (mismo namespace)
}
