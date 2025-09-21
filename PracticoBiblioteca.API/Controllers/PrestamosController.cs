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
        public async Task<ActionResult<IEnumerable<Prestamo>>> ObtenerTodos()
        {
            var prestamos = await _prestamoRepo.ObtenerTodosAsync();
            return Ok(prestamos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Prestamo>> ObtenerPorId(int id)
        {
            var prestamo = await _prestamoRepo.ObtenerPorIdAsync(id);
            if (prestamo == null) return NotFound();
            return Ok(prestamo);
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Prestamo>>> ObtenerPorUsuario(int usuarioId)
        {
            var prestamos = await _prestamoRepo.ObtenerPorUsuarioAsync(usuarioId);
            return Ok(prestamos);
        }

        [HttpPost]
        public async Task<ActionResult<Prestamo>> Crear([FromBody] Prestamo prestamo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var nuevoPrestamo = await _prestamoRepo.AgregarAsync(prestamo);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoPrestamo.Id }, nuevoPrestamo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] Prestamo prestamo)
        {
            if (id != prestamo.Id) return BadRequest();

            await _prestamoRepo.EditarAsync(prestamo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _prestamoRepo.EliminarAsync(id);
            return NoContent();
        }
    }
}
