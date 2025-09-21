using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoBiblioteca.Shared.DTOs
{
    public class RegistroDTO
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Clave { get; set; } = string.Empty;
        public string Rol { get; set; } = "Cliente"; // valor por defecto
    }
}
