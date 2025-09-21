using PracticoBiblioteca.Shared.DTOs;

namespace PracticoBiblioteca.API.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<SesionDTO?> AutenticacionAsync(LoginDTO login);

    }
}
