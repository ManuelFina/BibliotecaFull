using PracticoBiblioteca.Models;
using System.Collections.Generic;

namespace PracticoBiblioteca.Services.Interfaces;

public interface ILibroService
{
    List<Libro> ObtenerTodos();
    Libro? ObtenerPorId(int id);
    void Agregar(Libro libro);
    void Actualizar(Libro libro);
    void Eliminar(int id);
}
