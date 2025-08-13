namespace SistemaEducativoADB.API.Models.DTOs
{
    public class EstudianteCreateDto
    {
        public int IdUsuario { get; set; }
        public string nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int? IdCarrera { get; set; }
    }
}
