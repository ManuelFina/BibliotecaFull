using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticoBiblioteca.API.Repositories.Interfaces;
using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Shared.Models;

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

    [HttpPost("autenticacion")]
    [AllowAnonymous]
    public async Task<IActionResult> Autenticacion([FromBody] LoginDTO login)
    {
        try
        {
            var sesion = await _usuarioRepository.AutenticacionAsync(login);
            if (sesion == null) return Unauthorized("Credenciales inválidas o usuario inactivo.");
            return Ok(sesion);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en Autenticacion");
            return StatusCode(500, "Error interno al autenticar el usuario");
        }
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Registro(RegistroDTO dto)
    {
        try
        {
            var existe = await _usuarioRepository.ExistePorEmailAsync(dto.Email);
            if (existe) return BadRequest("Ya existe un usuario con ese correo");

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Email = dto.Email,
                Clave = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Rol = Roles.Cliente, // siempre cliente
                Activo = true
            };

            await _usuarioRepository.AgregarAsync(usuario);
            return Ok("Usuario registrado exitosamente");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en Registro");
            return StatusCode(500, "Error interno al registrar el usuario");
        }
    }

    [HttpGet]
    [AllowAnonymous]

    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
        try
        {
            var usuarios = await _usuarioRepository.ObtenerTodosAsync();
            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en GetUsuarios");
            return StatusCode(500, "Error interno al obtener usuarios");
        }
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
        try
        {
            var usuario = await _usuarioRepository.ObtenerPorIdAsync(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en GetUsuario");
            return StatusCode(500, "Error interno al obtener el usuario");
        }
    }

    [HttpPut("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult> PutUsuario(int id, [FromBody] Usuario usuario)
    {
        try
        {
            if (id != usuario.Id) return BadRequest("El ID no coincide");
            await _usuarioRepository.ActualizarAsync(usuario);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en PutUsuario");
            return StatusCode(500, "Error interno al actualizar el usuario");
        }
    }

    [HttpDelete("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult> DeleteUsuario(int id)
    {
        try
        {
            await _usuarioRepository.EliminarAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en DeleteUsuario");
            return StatusCode(500, "Error interno al eliminar el usuario");
        }
    }
}
