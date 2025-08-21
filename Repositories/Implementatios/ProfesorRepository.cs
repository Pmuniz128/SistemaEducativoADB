using Microsoft.EntityFrameworkCore;
using SistemaEducativoADB.API.Data;
using SistemaEducativoADB.API.Models.Entities;
using SistemaEducativoADB.API.Repositories.Interfaces;

namespace SistemaEducativoADB.API.Repositories.Implementatios
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly DbContext _context;

        public ProfesorRepository(DBContext context)
        {
            _context = context;
        }

        // Replace all occurrences of '_context.Profesors' with '_context.Set<Profesor>()'
        // This uses the generic Set<TEntity>() method of DbContext to access the Profesor DbSet.

        public async Task<IEnumerable<Profesor>> GetAllAsync()
        {
            return await _context.Set<Profesor>().ToListAsync();
        }

        public async Task<Profesor> GetByIdAsync(int id)
        {
            return await _context.Set<Profesor>().FindAsync(id);
        }

        public async Task AddAsync(Profesor Profesor)
        {
            await _context.Set<Profesor>().AddAsync(Profesor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Profesor Profesor)
        {
            _context.Set<Profesor>().Update(Profesor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Profesor = await GetByIdAsync(id);
            if (Profesor != null)
            {
                _context.Set<Profesor>().Remove(Profesor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
