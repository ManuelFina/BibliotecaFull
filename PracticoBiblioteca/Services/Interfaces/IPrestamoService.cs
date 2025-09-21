using PracticoBiblioteca.Shared.Models;

namespace PracticoBiblioteca.Services.Interfaces;

public interface IPrestamoService
{
    Task<List<Prestamo>> ObtenerTodos();
    Task<List<Prestamo>> ObtenerPorUsuario(string usuarioId);
    Task<Prestamo?> ObtenerPorId(int id);
    void SolicitarPrestamo(int libroId, string usuarioId);
    void AprobarPrestamo(int id);
    void DevolverPrestamo(int id);
    void Eliminar(int id);
}
