using Microsoft.AspNetCore.Mvc;
using PracticoBiblioteca.API.Repositories.Interfaces;
using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Shared.Models;

namespace PracticoBiblioteca.API.Controllers;

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
    public async Task<ActionResult<List<Prestamo>>> ObtenerTodos()
    {
        var prestamos = await _prestamoRepo.ObtenerTodosAsync();
        return Ok(prestamos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Prestamo>> ObtenerPorId(int id)
    {
        var prestamo = await _prestamoRepo.ObtenerPorIdAsync(id);
        if (prestamo == null)
            return NotFound();
        return Ok(prestamo);
    }

    [HttpGet("usuario/{usuarioId}")]
    public async Task<ActionResult<List<Prestamo>>> ObtenerPorUsuario(int usuarioId)
    {
        var prestamos = await _prestamoRepo.ObtenerPorUsuarioAsync(usuarioId);
        return Ok(prestamos);
    }

    [HttpPost]
    public async Task<ActionResult> Crear(PrestamoDTO dto)
    {
        var prestamo = new Prestamo
        {
            UsuarioId = dto.UsuarioId,
            LibroId = dto.LibroId,
            FechaPrestamo = DateTime.Now,
            FechaDevolucion = dto.FechaDevolucion,
            Devuelto = false
        };

        var creado = await _prestamoRepo.CrearAsync(prestamo);

        return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
    }

    [HttpPut("devolver/{id}")]
    public async Task<ActionResult> Devolver(int id)
    {
        var prestamo = await _prestamoRepo.ObtenerPorIdAsync(id);
        if (prestamo == null)
            return NotFound();

        await _prestamoRepo.DevolverAsync(id);
        return NoContent();
    }
}
