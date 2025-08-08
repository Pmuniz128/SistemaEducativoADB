using SistemaEducativoADB.API.Models.Entities;
using SistemaEducativoADB.API.Repositories.Interfaces;
using SistemaEducativoADB.API.Services.Interfaces;

namespace SistemaEducativoADB.API.Services.Implementations
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _repo;

        public EstudianteService(IEstudianteRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Estudiante> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
