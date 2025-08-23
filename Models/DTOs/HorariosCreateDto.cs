using System;

namespace SistemaEducativoADB.API.Models.DTOs
{
    public class HorariosCreateDto
    {
        public int id_grupo { get; set; }            
        public string dia_semana { get; set; } = ""; 
        public TimeSpan hora_inicio { get; set; }    
        public TimeSpan hora_fin { get; set; }     
    }
}

