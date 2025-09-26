using Microsoft.AspNetCore.Mvc;
using PracticoBiblioteca.API.Repositories.Interfaces;
using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Shared.Models;

namespace PracticoBiblioteca.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrestamosController(IPrestamoRepository prestamoRepo) : ControllerBase
{
    private readonly IPrestamoRepository _prestamoRepo = prestamoRepo;

    [HttpGet]
    public async Task<ActionResult<List<Prestamo>>> ObtenerTodos()
        => Ok(await _prestamoRepo.ObtenerTodosAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Prestamo>> ObtenerPorId(int id)
    {
        var prestamo = await _prestamoRepo.ObtenerPorIdAsync(id);
        return prestamo is null ? NotFound() : Ok(prestamo);
    }

    [HttpGet("usuario/{usuarioId}")]
    public async Task<ActionResult<List<Prestamo>>> ObtenerPorUsuario(int usuarioId)
        => Ok(await _prestamoRepo.ObtenerPorUsuarioAsync(usuarioId));

    [HttpPost]
    public async Task<ActionResult> Crear(PrestamoDTO dto)
    {
        var prestamo = new Prestamo
        {
            UsuarioId = dto.UsuarioId,
            LibroId = dto.LibroId,
            FechaDevolucion = dto.FechaDevolucion,
            FechaPrestamo = DateTime.Now,
            Devuelto = false
        };

        var creado = await _prestamoRepo.CrearAsync(prestamo);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
    }

    [HttpPut("devolver/{id}")]
    public async Task<ActionResult> Devolver(int id)
    {
        await _prestamoRepo.DevolverAsync(id);
        return NoContent();
    }
}
