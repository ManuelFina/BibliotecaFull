using PracticoBiblioteca.API.Data;
using PracticoBiblioteca.API.Repositories.Interfaces;
using PracticoBiblioteca.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace PracticoBiblioteca.API.Repositories.Implementaciones;

public class PrestamoRepository(DataContext context, ILogger<PrestamoRepository> logger) : IPrestamoRepository
{
    private readonly DataContext _context = context;
    private readonly ILogger<PrestamoRepository> _logger = logger;

    public async Task<Prestamo> CrearAsync(Prestamo prestamo)
    {
        try
        {
            await _context.Prestamos.AddAsync(prestamo);
            await _context.SaveChangesAsync();
            return prestamo;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear un préstamo");
            throw;
        }
    }

    public async Task<List<Prestamo>> ObtenerTodosAsync()
    {
        return await _context.Prestamos
            .Include(p => p.Usuario)
            .Include(p => p.Libro)
            .ToListAsync();
    }

    public async Task<Prestamo?> ObtenerPorIdAsync(int id)
    {
        return await _context.Prestamos
            .Include(p => p.Usuario)
            .Include(p => p.Libro)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Prestamo>> ObtenerPorUsuarioAsync(int usuarioId)
    {
        return await _context.Prestamos
            .Include(p => p.Libro)
            .Where(p => p.UsuarioId == usuarioId)
            .ToListAsync();
    }

    public async Task DevolverAsync(int prestamoId)
    {
        var prestamo = await _context.Prestamos.FindAsync(prestamoId);
        if (prestamo != null && !prestamo.Devuelto)
        {
            prestamo.Devuelto = true;
            await _context.SaveChangesAsync();
        }
    }
}
