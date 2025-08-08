using SistemaEducativoADB.API.Models.Entities;

namespace SistemaEducativoADB.API.Repositories.Interfaces
{
    public interface IEstudianteRepository
    {
        IEnumerable<Estudiante> GetAll();
    }
}
