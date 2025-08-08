using SistemaEducativoADB.API.Models.Entities;

namespace SistemaEducativoADB.API.Services.Interfaces
{
    public interface IEstudianteService
    {
        IEnumerable<Estudiante> GetAll();
    }
}
