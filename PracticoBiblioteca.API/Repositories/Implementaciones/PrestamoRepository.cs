using PracticoBiblioteca.API.Data;
using Microsoft.EntityFrameworkCore;
using PracticoBiblioteca.API.Repositories.Interfaces;
using PracticoBiblioteca.Shared.Models;


namespace PracticoBiblioteca.API.Repositories.Implementaciones
{
    public class PrestamoRepository(DataContext context) : IPrestamoRepository
    {
        private readonly DataContext _context = context;

        public async Task<IEnumerable<Prestamo>> ObtenerTodosAsync()
        {
            return await _context.Prestamos
                .Include(p => p.Libro)
                .Include(p => p.Usuario)
                .ToListAsync();
        }

        public async Task<Prestamo?> ObtenerPorIdAsync(int id)
        {
            return await _context.Prestamos
                .Include(p => p.Libro)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Prestamo>> ObtenerPorUsuarioAsync(int usuarioId)
        {
            return await _context.Prestamos
                //.Where(p => p.UsuarioId == usuarioId)
                .Include(p => p.Libro)
                .ToListAsync();
        }

        public async Task<Prestamo> AgregarAsync(Prestamo prestamo)
        {
            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();
            return prestamo;
        }

        public async Task EditarAsync(Prestamo prestamo)
        {
            _context.Prestamos.Update(prestamo);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo != null)
            {
                _context.Prestamos.Remove(prestamo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
