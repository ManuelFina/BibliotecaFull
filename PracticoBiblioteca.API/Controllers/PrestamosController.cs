using Microsoft.AspNetCore.Mvc;
using PracticoBiblioteca.API.Repositories.Interfaces;
using PracticoBiblioteca.Shared.Models;

namespace BibliotecaFull.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamosController : ControllerBase
    {
        private readonly IPrestamoRepository _prestamoRepo;

        public PrestamosController(IPrestamoRepository prestamoRepo)
        {
            _prestamoRepo = prestamoRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prestamo>>> GetAll()
        {
            var prestamos = await _prestamoRepo.GetAllAsync();
            return Ok(prestamos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Prestamo>> GetById(int id)
        {
            var prestamo = await _prestamoRepo.GetByIdAsync(id);
            if (prestamo == null) return NotFound();
            return Ok(prestamo);
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Prestamo>>> GetByUsuario(int usuarioId)
        {
            var prestamos = await _prestamoRepo.GetByUsuarioAsync(usuarioId);
            return Ok(prestamos);
        }

        [HttpPost]
        public async Task<ActionResult<Prestamo>> Create([FromBody] Prestamo prestamo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var nuevoPrestamo = await _prestamoRepo.AddAsync(prestamo);
            return CreatedAtAction(nameof(GetById), new { id = nuevoPrestamo.Id }, nuevoPrestamo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Prestamo prestamo)
        {
            if (id != prestamo.Id) return BadRequest();

            await _prestamoRepo.UpdateAsync(prestamo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _prestamoRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
