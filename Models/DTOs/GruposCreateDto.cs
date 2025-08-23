using SistemaEducativoADB.API.Models.Entities;

namespace SistemaEducativoADB.API.Models.DTOs
{
    public class GruposCreateDto
    {
        public int id_materia { get; set; }
        public int id_profesor { get; set; }
        public string grupo_numero { get; set; } = "";
        public string aula { get; set; } = "";         
        public int cupo_max { get; set; }             
    }
}

