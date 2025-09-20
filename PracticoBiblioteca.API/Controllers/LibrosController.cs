using Microsoft.AspNetCore.Mvc;
using PracticoBiblioteca.Shared.Models;
using PracticoBiblioteca.API.Repositories.Interfaces;

namespace PracticoBiblioteca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly ILibroRepository _libroRepository;

        public LibroController(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        // GET: api/Libro
        [HttpGet]
        public async Task<ActionResult<List<Libro>>> GetTodos()
        {
            try
            {
                var libros = await _libroRepository.ObtenerTodosAsync();
                return Ok(libros);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // GET: api/Libro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetPorId(int id)
        {
            try
            {
                var libro = await _libroRepository.ObtenerPorIdAsync(id);
                if (libro == null)
                    return NotFound($"No se encontró el libro con Id {id}.");

                return Ok(libro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST: api/Libro
        [HttpPost]
        public async Task<ActionResult> Crear(Libro libro)
        {
            try
            {
                await _libroRepository.AgregarAsync(libro);
                return CreatedAtAction(nameof(GetPorId), new { id = libro.Id }, libro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT: api/Libro/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, Libro libro)
        {
            try
            {
                if (id != libro.Id)
                    return BadRequest("El Id del libro no coincide.");

                await _libroRepository.ActualizarAsync(libro);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE: api/Libro/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                var existingLibro = await _libroRepository.ObtenerPorIdAsync(id);
                if (existingLibro == null)
                    return NotFound($"No se encontró el libro con Id {id}.");

                await _libroRepository.EliminarAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
