using Microsoft.AspNetCore.Http.HttpResults;

namespace SistemaEducativoADB.API.Models.DTOs
{
    public class ProfesorCreateDto
    {
        public int IdProfesor { get; set; }
        public int cedula { get; set; }
        public string Telefono { get; set; }
        public string CorreoPersonal { get; set; }
    }
}
