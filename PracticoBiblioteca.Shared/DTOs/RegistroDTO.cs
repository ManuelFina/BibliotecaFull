using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoBiblioteca.Shared.DTOs
{
    public class RegistroDTO
    {
        public required string Nombre { get; set; } 
        public required string Email { get; set; } 
        public required string Password { get; set; } 
    }
}
