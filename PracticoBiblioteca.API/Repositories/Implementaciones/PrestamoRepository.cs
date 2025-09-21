using PracticoBiblioteca.API.Data;
using Microsoft.EntityFrameworkCore;
using PracticoBiblioteca.API.Repositories.Interfaces;
using PracticoBiblioteca.Shared.Models;


namespace PracticoBiblioteca.API.Repositories.Implementaciones
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly DataContext _context;

        public PrestamoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prestamo>> GetAllAsync()
        {
            return await _context.Prestamos
                .Include(p => p.Libro)
                .Include(p => p.Usuario)
                .ToListAsync();
        }

        public async Task<Prestamo?> GetByIdAsync(int id)
        {
            return await _context.Prestamos
                .Include(p => p.Libro)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Prestamo>> GetByUsuarioAsync(int usuarioId)
        {
            return await _context.Prestamos
                //.Where(p => p.UsuarioId == usuarioId)
                .Include(p => p.Libro)
                .ToListAsync();
        }

        public async Task<Prestamo> AddAsync(Prestamo prestamo)
        {
            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();
            return prestamo;
        }

        public async Task UpdateAsync(Prestamo prestamo)
        {
            _context.Prestamos.Update(prestamo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
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
