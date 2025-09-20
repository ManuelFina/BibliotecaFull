using PracticoBiblioteca.Shared.Models;
using System.Collections.Generic;

namespace PracticoBiblioteca.Services.Interfaces;

public interface ILibroService
{
    Task <List<Libro>> ObtenerTodos();
    Task <Libro?> ObtenerPorId(int id);
    void Agregar(Libro libro);
    void Actualizar(Libro libro);
    void Eliminar(int id);
}
