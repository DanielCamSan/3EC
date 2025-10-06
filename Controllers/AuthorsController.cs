using apiwithdb.Models.dtos;
using apiwithdb.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiwithdb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;
        public AuthorsController(IAuthorService service) { _service = service; }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAll();
            return Ok(items);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var author = await _service.GetById(id);
            return author is null
                ? NotFound(new { error = "Author not found", status = 404 })
                : Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            try
            {
                var author = await _service.Create(dto);
                return CreatedAtAction(nameof(GetOne), new { id = author.Id }, author);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { error = ex.Message, status = 409 });
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAuthorDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            try
            {
                var updated = await _service.Update(id, dto);
                return updated is null
                    ? NotFound(new { error = "Author not found", status = 404 })
                    : Ok(updated);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { error = ex.Message, status = 409 });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.Delete(id);
            // false => no existe o tiene libros; puedes diferenciar si quieres
            return success
                ? NoContent()
                : NotFound(new { error = "Author not found or has related books", status = 404 });
        }
    }
}
