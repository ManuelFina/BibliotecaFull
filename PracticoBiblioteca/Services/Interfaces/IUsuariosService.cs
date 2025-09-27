using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Shared.Models;
using System.Collections.Generic;

namespace PracticoBiblioteca.Services.Interfaces;

public interface IUsuarioService
{
    Task<SesionDTO?> AutenticacionAsync(LoginDTO login);
    Task<Usuario> RegistrarAsync(RegistroDTO dto);
    Task<List<Usuario>> ObtenerTodosAsync();
    Task<Usuario?> ObtenerPorIdAsync(int id);
    Task AgregarAsync(Usuario usuario);
    Task ActualizarAsync(Usuario usuario);
    Task EliminarAsync(int id);
}
