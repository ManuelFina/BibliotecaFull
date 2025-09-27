using Microsoft.EntityFrameworkCore;
using PracticoBiblioteca.Shared.Models;
using PracticoBiblioteca.Shared.DTOs;

namespace PracticoBiblioteca.API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Libro> Libros { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Prestamo> Prestamos { get; set; }

}