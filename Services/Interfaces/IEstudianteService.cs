using SistemaEducativoADB.API.Models.Entities;

namespace SistemaEducativoADB.API.Services.Interfaces
{
    public interface IEstudianteService
    {
        Task<IEnumerable<Estudiante>> GetAllEstudiantes();
        Task<Estudiante> GetEstudianteById(int id);
        Task AddEstudiante(Estudiante estudiante);
        Task UpdateEstudiante(Estudiante estudiante);
        Task DeleteEstudiante(int id);
    }
}
