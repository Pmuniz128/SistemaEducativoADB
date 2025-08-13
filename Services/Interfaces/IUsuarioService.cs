using SistemaEducativoADB.API.Models.Entities;

namespace SistemaEducativoADB.API.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAllUsuarios();
        Task<Usuario> GetUsuarioById(int id);
        Task AddUsuario(Usuario Usuario);
        Task UpdateUsuario(Usuario Usuario);
        Task DeleteUsuario(int id);
    }
}
