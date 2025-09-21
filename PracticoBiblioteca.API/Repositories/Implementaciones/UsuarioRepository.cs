using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PracticoBiblioteca.API.Data;
using PracticoBiblioteca.API.Repositories.Interfaces;
using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Shared.Models;
using BCrypt.Net;

namespace PracticoBiblioteca.API.Repositories.Implementaciones
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<UsuarioRepository> _logger;

        public UsuarioRepository(DataContext context, ILogger<UsuarioRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        // 🔹 Autenticación
        public async Task<SesionDTO?> AutenticacionAsync(LoginDTO login)
        {
            try
            {
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == login.Email && u.Activo);

                if (usuario == null) return null;

                // Verificar hash
                bool claveValida = BCrypt.Net.BCrypt.Verify(login.Password, usuario.Clave);
                if (!claveValida) return null;

                return new SesionDTO
                {
                    Token = Guid.NewGuid().ToString(), // luego reemplazar por JWT
                    Expiracion = DateTime.Now.AddHours(24),
                    Email = usuario.Email
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al autenticar login");
                throw;
            }
        }
        public async Task<Usuario?> RegistrarAsync(RegistroDTO registroDto)
        {
            try
            {
                var existente = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == registroDto.Email);
                if (existente != null) return null;

                var hashedClave = BCrypt.Net.BCrypt.HashPassword(registroDto.Clave);

                var usuario = new Usuario
                {
                    Nombre = registroDto.Nombre,
                    Email = registroDto.Email,
                    Clave = hashedClave,
                    Rol = registroDto.Rol ?? "Cliente",
                    Activo = true
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return usuario;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar usuario");
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

        public async Task<Usuario?> ObtenerPorEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
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
