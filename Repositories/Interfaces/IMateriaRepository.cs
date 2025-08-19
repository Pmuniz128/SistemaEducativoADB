using SistemaEducativoADB.API.Models.Entities;

namespace SistemaEducativoADB.API.Repositories.Interfaces
{
    public interface IMateriaRepository
    {
        Task<IEnumerable<Materia>> GetAllAsync();
        Task<Materia> GetByIdAsync(int id);
        Task AddAsync(Materia Materia);
        Task UpdateAsync(Materia Materia);
        Task DeleteAsync(int id);
    }
}
