using SistemaEducativoADB.API.Models.Entities;

namespace SistemaEducativoADB.API.Services.Interfaces
{
    public interface IMateriaService
    {
        Task<IEnumerable<Materia>> GetAllMaterias();
        Task<Materia> GetMateriaById(int id);
        Task AddMateria(Materia Materia);
        Task UpdateMateria(Materia Materia);
        Task DeleteMateria(int id); 
        Task DeleteMateriaById(int id);
    }
}
