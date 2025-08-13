using SistemaEducativoADB.API.Models.Entities;

namespace SistemaEducativoADB.API.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task AddAsync(Usuario Usuario);
        Task UpdateAsync(Usuario Usuario);
        Task DeleteAsync(int id);
    }
}
