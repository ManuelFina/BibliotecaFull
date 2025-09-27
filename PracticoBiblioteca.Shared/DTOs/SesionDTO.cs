using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoBiblioteca.Shared.DTOs
{
    public class SesionDTO
    {
        public int UsuarioId { get; set; }
        public required string Token { get; set; } = string.Empty;
        public required DateTime Expiracion { get; set; } = DateTime.Now.AddHours(24);
        public required string Email { get; set; } = string.Empty;
        public required string Rol { get; set; } = "Cliente";
    }
}
