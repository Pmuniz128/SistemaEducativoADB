using Microsoft.AspNetCore.Mvc;
using SistemaEducativoADB.API.Services.Interfaces;

namespace SistemaEducativoADB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteService _service;

        public EstudiantesController(IEstudianteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var estudiantes = _service.GetAll();
            return Ok(estudiantes);
        }
    }
}
