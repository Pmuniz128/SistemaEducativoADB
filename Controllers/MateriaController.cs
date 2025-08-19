using Microsoft.AspNetCore.Mvc;
using SistemaEducativoADB.API.Models.DTOs;
using SistemaEducativoADB.API.Models.Entities;
using SistemaEducativoADB.API.Services;
using SistemaEducativoADB.API.Services.Interfaces;

namespace SistemaEducativoADB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly IMateriaService _service;

        public MateriasController(IMateriaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Materias = await _service.GetAllMaterias();
            return Ok(Materias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Materia = await _service.GetMateriaById(id);
            if (Materia == null) return NotFound();
            return Ok(Materia);
        }

        [HttpPost]
        public async Task<IActionResult> CrearMateria([FromBody] MateriaCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos");

            var materia = new Materia
            {
                Codigo = dto.Codigo,
                Nombre = dto.Nombre,
                Creditos = dto.Creditos,
                IdPlan = dto.IdPlan
            };

            await _service.AddMateria(materia);

            return CreatedAtAction(nameof(GetById), new { id = materia.IdMateria }, materia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Materia Materia)
        {
            if (id != Materia.IdMateria) return BadRequest();
            await _service.UpdateMateria(Materia);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteMateria(id);
            return NoContent();
        }
    }
}
