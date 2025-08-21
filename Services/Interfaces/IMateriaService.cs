using SistemaEducativoADB.API.Models.Entities;

namespace SistemaEducativoADB.API.Services.Interfaces
{
    public interface IMateriaService
    {
        Task<IEnumerable<Materia>> GetAllMaterias();
        Task<Materia> GetMateriaById(int id);
        Task AddMateria(Materia materia);
        Task UpdateMateria(Materia materia);
        Task DeleteMateria(int id);
    }
}