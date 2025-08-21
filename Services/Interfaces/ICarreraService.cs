using SistemaEducativoADB.API.Models.Entities;

namespace SistemaEducativoADB.API.Services.Interfaces
{ 
    public interface ICarreraService
    {
        Task<IEnumerable<Carrera>> GetAllCarreras();
        Task<Carrera> GetCarreraById(int id);
        Task AddCarrera(Carrera carrera);
        Task UpdateCarrera(Carrera carrera);
        Task DeleteCarrera(int id);
    }
}

