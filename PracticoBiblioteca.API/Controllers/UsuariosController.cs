using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticoBiblioteca.API.Repositories.Interfaces;
using PracticoBiblioteca.API.Repositories.Implementaciones;
using PracticoBiblioteca.Shared.DTOs;


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
        public async Task<IActionResult> Authenticate([FromBody] LoginDTO login)
        {
            try
            {
                var sesion = await _usuarioRepository.AuthenticateAsync(login);

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
    }
}