using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoBiblioteca.Shared.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Clave { get; set; } = string.Empty;
        [Required]
        public string? Rol { get; set; } = "Cliente";
        [Required]
        public bool Activo { get; set; }
        public string Imagen { get; set; } = string.Empty;

        // Relación con Préstamos
        public List<Prestamo> Prestamos { get; set; } = [];
    }
}
