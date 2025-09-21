using Microsoft.EntityFrameworkCore;
using PracticoBiblioteca.API.Data;
using PracticoBiblioteca.API.Repositories.Interfaces;
using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Shared.Models;


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

        public async Task<SesionDTO?> AuthenticateAsync(LoginDTO login)
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

        public Task CreateAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
