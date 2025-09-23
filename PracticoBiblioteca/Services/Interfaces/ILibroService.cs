using PracticoBiblioteca.Shared.Models;
using System.Collections.Generic;

namespace PracticoBiblioteca.Services.Interfaces;

public interface ILibroService
{
    Task <List<Libro>> ObtenerTodos();
    Task <Libro?> ObtenerPorId(int id);
    Task Agregar(Libro libro);
    Task Actualizar(Libro libro);
    Task Eliminar(int id);
}
