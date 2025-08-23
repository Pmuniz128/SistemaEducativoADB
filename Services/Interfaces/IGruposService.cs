using SistemaEducativoADB.API.Models.Entities;

namespace SistemaEducativoADB.API.Services.Interfaces
{
    public interface IGruposService
    {
        Task<IEnumerable<Grupo>> GetAllGrupos();
        Task<Grupo?> GetGrupoById(int id);
        Task AddGrupo(Grupo grupo);
        Task UpdateGrupo(Grupo grupo);
        Task DeleteGrupo(int id);
        Task<IEnumerable<Grupo>> GetByMateria(int id_materia);
        Task<IEnumerable<Grupo>> GetByProfesor(int id_profesor);
        Task<bool> ExistsForMateriaNumero(int id_materia, string grupo_numero);
    }
}
