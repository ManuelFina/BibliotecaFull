using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticoBiblioteca.API.Repositories.Interfaces;
using PracticoBiblioteca.Shared.Models;
using System.Security.Claims;

namespace PracticoBiblioteca.API.Controllers
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Prestamo>>> ObtenerTodos()
        {
            var prestamos = await _prestamoRepo.ObtenerTodosAsync();
            return Ok(prestamos);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Cliente")]
        public async Task<ActionResult<Prestamo>> ObtenerPorId(int id)
        {
            var prestamo = await _prestamoRepo.ObtenerPorIdAsync(id);
            if (prestamo == null) return NotFound();
            return Ok(prestamo);
        }

        [HttpGet("usuario/{usuarioId}")]
        [Authorize(Roles = "Admin,Cliente")]
        public async Task<ActionResult<IEnumerable<Prestamo>>> ObtenerPorUsuario(int usuarioId)
        {
            var prestamos = await _prestamoRepo.ObtenerPorUsuarioAsync(usuarioId);
            return Ok(prestamos);
        }

        [HttpPost]
        [Authorize(Roles = "Cliente")]
        public async Task<ActionResult<Prestamo>> Crear([FromBody] Prestamo prestamo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 🔹 Obtener el usuario autenticado desde el token
            var usuarioIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (usuarioIdClaim == null)
                return Unauthorized("No se pudo determinar el usuario autenticado.");

            if (!int.TryParse(usuarioIdClaim, out var usuarioId))
                return Unauthorized("El claim de usuario no es válido.");

            prestamo.UsuarioId = usuarioId;

            var prestamosUsuario = await _prestamoRepo.ObtenerPorUsuarioAsync(prestamo.UsuarioId);

            var yaTienePrestamo = prestamosUsuario
                .Any(p => p.LibroId == prestamo.LibroId && p.Estado != "Devuelto");

            if (yaTienePrestamo)
                return BadRequest("Ya tienes un préstamo activo de este libro.");

            prestamo.FechaPrestamo = DateTime.Now;
            prestamo.Estado = "Pendiente";

            var nuevoPrestamo = await _prestamoRepo.AgregarAsync(prestamo);

            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoPrestamo.Id }, nuevoPrestamo);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Editar(int id, [FromBody] Prestamo prestamo)
        {
            if (id != prestamo.Id) return BadRequest();

            await _prestamoRepo.EditarAsync(prestamo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _prestamoRepo.EliminarAsync(id);
            return NoContent();
        }
    }
}
