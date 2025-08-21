using SistemaEducativoADB.API.Models.Entities;

namespace SistemaEducativoADB.API.Repositories.Interfaces
{
    public interface IMateriaRepository
    {
        Task<IEnumerable<Materia>> GetAllAsync();
        Task<Materia> GetByIdAsync(int id);
        Task AddAsync(Materia materia);
        Task UpdateAsync(Materia materia);
        Task DeleteAsync(int id);
    }
}
