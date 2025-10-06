using apiwithdb.Models.dtos;

namespace apiwithdb.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorListDto>> GetAll();
        Task<AuthorDetailDto?> GetById(Guid id);
        Task<AuthorDetailDto> Create(CreateAuthorDto dto);
        Task<AuthorDetailDto?> Update(Guid id, UpdateAuthorDto dto);
        Task<bool> Delete(Guid id); // false => no existe o tiene libros
    }
}
