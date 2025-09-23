using System.ComponentModel.DataAnnotations;

namespace PracticoBiblioteca.Shared.Models;

public class Libro
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Imagen { get; set; } = string.Empty;
    public int AñoPublicacion { get; set; }

}
