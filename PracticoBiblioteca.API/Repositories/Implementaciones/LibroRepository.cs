using PracticoBiblioteca.Shared.Models;
using PracticoBiblioteca.API.Data;
using PracticoBiblioteca.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PracticoBiblioteca.API.Repositories.Implementaciones
{
    public class LibroRepository(DataContext context, ILogger<LibroRepository> logger) : ILibroRepository
    {
        private readonly DataContext _context = context;
        private readonly ILogger<LibroRepository> _logger = logger;

        public async Task AgregarAsync(Libro libro)
        {
            try
            {
                await _context.Libros.AddAsync(libro);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar un libro.");
                throw;
            }
        }

        public async Task ActualizarAsync(Libro libro)
        {
            try
            {
                _context.Libros.Update(libro);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar un libro.");
                throw;
            }
        }

        public async Task EliminarAsync(int id)
        {
            try
            {
                var libro = await _context.Libros.FindAsync(id);
                if (libro != null)
                {
                    _context.Libros.Remove(libro);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar un libro.");
                throw;
            }
        }

        public async Task<List<Libro>> ObtenerTodosAsync()
        {
            try
            {
                return await _context.Libros.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los libros.");
                throw;
            }
        }

        public async Task<Libro?> ObtenerPorIdAsync(int id)
        {
            try
            {
                return await _context.Libros.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el libro con Id {id}.");
                throw;
            }
        }
    }
}
