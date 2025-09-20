namespace PracticoBiblioteca.Models;

public class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Imagen { get; set; } = string.Empty;
    public int AñoPublicacion { get; set; }
}
