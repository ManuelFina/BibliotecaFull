using PracticoBiblioteca.Shared.Models;
using PracticoBiblioteca.Services.Interfaces;

namespace PracticoBiblioteca.Services.Implementaciones;

public class UsuarioService : IUsuarioService
{
    private readonly List<Usuario> _usuarios =
    [
        new Usuario
        { 
            Id = 1, 
            Nombre = "Admin",
            Email = "admin@biblioteca.com", 
            Clave = "admin", 
            Imagen = "img/admin.png"
        },
    ];

    public List<Usuario> ObtenerTodos() => _usuarios;

    public Usuario? ObtenerPorCredenciales(string email, string clave) =>
        _usuarios.FirstOrDefault(u => u.Email == email && u.Clave == clave);

    public void Agregar(Usuario usuario)
    {
        usuario.Id = _usuarios.Max(u => u.Id) + 1;
        _usuarios.Add(usuario);
    }

    public void Actualizar(Usuario usuario)
    {
        var index = _usuarios.FindIndex(u => u.Id == usuario.Id);
        if (index >= 0) _usuarios[index] = usuario;
    }

    public void Eliminar(int id) => _usuarios.RemoveAll(u => u.Id == id);
}
