using Microsoft.EntityFrameworkCore;
using SistemaEducativoADB.API.Data;
using SistemaEducativoADB.API.Models.Entities;
using SistemaEducativoADB.API.Repositories.Interfaces;

namespace SistemaEducativoADB.API.Repositories.Implementatios
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly SistemaEducativoContext _context;

        public EstudianteRepository(SistemaEducativoContext context)
        {
            _context = context;
        }

        public IEnumerable<Estudiante> GetAll()
        {
            return _context.Estudiantes.ToList();
        }
    }
}
