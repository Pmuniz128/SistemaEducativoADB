using SistemaEducativoADB.API.Models.Entities;
using SistemaEducativoADB.API.Repositories.Interfaces;
using SistemaEducativoADB.API.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SistemaEducativoADB.API.Services
{
    public class MateriaService : IMateriaService
    {
        private readonly IMateriaRepository _repository;

        public MateriaService(IMateriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Materia>> GetAllMaterias()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Materia> GetMateriaById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddMateria(Materia Materia)
        {
            await _repository.AddAsync(Materia);
        }

        public async Task UpdateMateria(Materia Materia)
        {
            await _repository.UpdateAsync(Materia);
        }

        public async Task DeleteMateria(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public Task DeleteMateriaById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
