using Microsoft.EntityFrameworkCore;
using PracticoBiblioteca.Models;

namespace PracticoBiblioteca.API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Libro> Productos { get; set; }
    //public DbSet<Usuario> Usuarios { get; set; }
}