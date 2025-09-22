using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticoBiblioteca.Shared.Models;

public class Prestamo
{
    [Key]
    public int Id { get; set; }

    // Relación con Usuario
    [Required]
    public int UsuarioId { get; set; } 

    [ForeignKey(nameof(UsuarioId))]
    public Usuario Usuario { get; set; } = null!;

    // Relación con Libro
    [Required]
    public int LibroId { get; set; }

    [ForeignKey(nameof(LibroId))]
    public Libro Libro { get; set; } = null!;

    // Fechas
    [Required]
    public DateTime FechaPrestamo { get; set; } = DateTime.Now;

    public DateTime? FechaDevolucion { get; set; }

    // Estado (Pendiente, Aprobado, Devuelto, Rechazado)
    [Required]
    [MaxLength(20)]
    public string Estado { get; set; } = "Pendiente";
}
