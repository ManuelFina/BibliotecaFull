using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PracticoBiblioteca.API.Controllers
{
    public class UsuariosController : Controller
    {
        /*
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(IUsuarioRepository usuarioRepository, ILogger<UsuariosController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Shared.DTO.LoginDTO login)
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
        */
    }
}
