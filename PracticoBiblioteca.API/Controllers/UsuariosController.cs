using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticoBiblioteca.API.Repositories.Implementaciones;
using PracticoBiblioteca.API.Repositories.Interfaces;
using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Shared.Models;


namespace PracticoBiblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(IUsuarioRepository usuarioRepository, ILogger<UsuariosController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Autenticacion([FromBody] LoginDTO login)
        {
            try
            {
                var sesion = await _usuarioRepository.AutenticacionAsync(login);

                if (sesion == null)
                {
                    return Unauthorized("Credenciales inválidas o usuario inactivo.");
                }
                return Ok(sesion);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en Authenticate. Detalle: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor");
            }
        }

        // GET: api/usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            try
            {
                var usuarios = await _usuarioRepository.ObtenerTodosAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener usuarios: {ex.Message}");
            }
        }

        // GET: api/usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _usuarioRepository.ObtenerPorIdAsync(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        // POST: api/usuarios
        [HttpPost]
        public async Task<ActionResult> PostUsuario([FromBody] Usuario usuario)
        {
            await _usuarioRepository.AgregarAsync(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // PUT: api/usuarios/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest("El ID no coincide");

            await _usuarioRepository.ActualizarAsync(usuario);
            return NoContent();
        }

        // DELETE: api/usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            await _usuarioRepository.EliminarAsync(id);
            return NoContent();
        }
    }
}
