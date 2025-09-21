using Microsoft.EntityFrameworkCore;
using PracticoBiblioteca.API.Data;
using PracticoBiblioteca.API.Repositories.Interfaces;
using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Shared.Models;


namespace PracticoBiblioteca.API.Repositories.Implementaciones
{
    public class UsuarioRepository(DataContext context, ILogger<UsuarioRepository> logger) : IUsuarioRepository
    {
        private readonly DataContext _context = context;
        private readonly ILogger<UsuarioRepository> _logger = logger;

        public async Task<SesionDTO?> AutenticacionAsync(LoginDTO login)
        {
            try
            {

                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == login.Email && u.Clave == login.Password && u.Activo == true);
                if (usuario == null) return null;

                return new SesionDTO
                {
                    Token = Guid.NewGuid().ToString(),
                    Expiracion = DateTime.Now.AddHours(24),
                    Email = usuario.Email
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al autenticar login. Detalle: {ex.Message}");
                throw;
            }

        }

        public async Task<List<Usuario>> ObtenerTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> ObtenerPorIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task AgregarAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}

