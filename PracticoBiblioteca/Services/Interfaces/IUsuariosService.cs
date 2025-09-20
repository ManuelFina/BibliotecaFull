using PracticoBiblioteca.Shared.Models;
using System.Collections.Generic;

namespace PracticoBiblioteca.Services.Interfaces;

public interface IUsuarioService
{
    List<Usuario> ObtenerTodos();
    Usuario? ObtenerPorCredenciales(string email, string clave);
    void Agregar(Usuario usuario);
    void Actualizar(Usuario usuario);
    void Eliminar(int id);
}
