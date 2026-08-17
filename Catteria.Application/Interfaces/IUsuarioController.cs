using Catteria.Application.DTOs;

namespace Catteria.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> GetAllAsync();
        Task<UsuarioDto?> GetByIdAsync(string id);
        Task<(bool Success, UsuarioDto? Usuario, string ErrorMessage)> CreateAsync(CreateUsuarioDto dto);
        Task<UsuarioDto?> UpdateAsync(string id, UpdateUsuarioDto dto);
        Task<(bool Success, string ErrorMessage)> DeleteAsync(string id);
        Task<IEnumerable<string>> GetPerfisAsync();
    }
}
