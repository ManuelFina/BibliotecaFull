using PracticoBiblioteca.Shared.Models;


namespace PracticoBiblioteca.API.Repositories.Interfaces
{
    public interface ILibroRepository
    {
        Task<List<Libro>> ObtenerTodosAsync();
        Task<Libro?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Libro libro);
        Task ActualizarAsync(Libro libro);
        Task EliminarAsync(int id);
    }
}
