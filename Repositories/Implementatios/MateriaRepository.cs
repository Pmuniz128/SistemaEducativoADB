using Microsoft.EntityFrameworkCore;
using SistemaEducativoADB.API.Data;
using SistemaEducativoADB.API.Models.Entities;
using SistemaEducativoADB.API.Repositories.Interfaces;

namespace SistemaEducativoADB.API.Repositories.Implementatios
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly DbContext _context;

        public MateriaRepository(DBContext context)
        {
            _context = context;
        }

        // Replace all occurrences of '_context.Materias' with '_context.Set<Materia>()'
        // This uses the generic Set<TEntity>() method of DbContext to access the Materia DbSet.

        public async Task<IEnumerable<Materia>> GetAllAsync()
        {
            return await _context.Set<Materia>().ToListAsync();
        }

        public async Task<Materia> GetByIdAsync(int id)
        {
            return await _context.Set<Materia>().FindAsync(id);
        }

        public async Task AddAsync(Materia Materia)
        {
            await _context.Set<Materia>().AddAsync(Materia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Materia Materia)
        {
            _context.Set<Materia>().Update(Materia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Materia = await GetByIdAsync(id);
            if (Materia != null)
            {
                _context.Set<Materia>().Remove(Materia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
